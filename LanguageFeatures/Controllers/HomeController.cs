using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            List<string> results = new List<string>();
            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";
                //results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
                results.Add($"Name: {name}, Price: {price}, Related: {relatedName}");
            }

            return View(results);
            //return View(new string[] { "C#", "Language", "Features" });
        }

        public ViewResult IndexA()
        {
            string[] names = new string[3];
            names[0] = "Bob";
            names[1] = "Joe";
            names[2] = "Alice";
            return View("Index", names);
        }
        //ABOVE INDEX CAN BE WRITTEN AS BELOW

        public ViewResult IndexB()
        {
            return View("Index", new string[] { "Bob", "Joe", "Alice" });
        }




        public ViewResult IndexC()
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                { "Kayak", new Product { Name = "Kayak", Price = 275M } },
                { "Lifejacket", new Product { Name = "Lifejacket", Price = 48.95M } }
            };
            return View("Index", products.Keys);
        }

        //ABOVE INDEX CAN BE WRITTEN AS BELOW

        public ViewResult IndexD()
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
                ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M }
            };
            return View("Index", products.Keys);
        }

    }
}
