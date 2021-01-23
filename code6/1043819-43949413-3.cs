    using LiteRemit.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace LiteRemit.Controllers
    {
        public class HomeController : Controller
        {
            MySqlCon _con;
            public HomeController()
            {
                _con = new MySqlCon();
            }
    
            public ActionResult Index()
            {
                return View(_con.Customers.ToList());
            }
    }
    }
