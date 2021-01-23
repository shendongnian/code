    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace ChuckApplication.Controllers
    {
        public class SelectlistController : Controller
        {
            //
            // GET: /Selectlist/
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpPost]
            public JsonResult ProcessSelection(string selectedOption, string[] availableOptions)
            {
                //Do whatever you want with the selection result, I recommend you use a repository to handle it. 
    
    
                return Json("Success");
            }
    	}
    }
