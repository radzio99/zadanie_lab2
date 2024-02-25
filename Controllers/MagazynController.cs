using Microsoft.AspNetCore.Mvc;
using LAB2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LAB2.Controllers
{
    public class MagazynController : Controller
    {
        private static IList<Magazyn> products = new List<Magazyn>()
        {
            new Magazyn(){Id = 1, Produkt = "Spodnie" , Cena = 45, Ilosc = 7}
        };



      
        public ActionResult Index()
        {
            return View(products);
        }

     
        public ActionResult Details(int id)
        {
            return View(products.FirstOrDefault(x => x.Id == id));
        }

      

        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Magazyn product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return RedirectToAction("Index");

        }

      
        public ActionResult Edit(int id)
        {
            return View(products.FirstOrDefault(x => x.Id == id));
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Magazyn product)
        {
            Magazyn product1 = products.FirstOrDefault(x => x.Id == id);
            product1.Produkt = product.Produkt;
            product1.Cena = product.Cena;
            product1.Ilosc = product.Ilosc;

            return RedirectToAction("Index");
        }

     
        public ActionResult Delete(int id)
        {
            return View(products.FirstOrDefault(x => x.Id == id));
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Magazyn product)
        {
            Magazyn product1 = products.FirstOrDefault(x => x.Id == id);
            products.Remove(product1);

            return RedirectToAction("Index");

        }
    }
}