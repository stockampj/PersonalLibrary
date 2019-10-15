using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    public class  BooksController : Controller
    {
        private readonly LibraryContext _db;

        public  BooksController (LibraryContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Book> model = _db.Books.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}