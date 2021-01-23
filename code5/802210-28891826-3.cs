	// Post JSON data  add using System.Net;
		[HttpPost]
        public JsonResult JsonFullName(string fname, string lastname)
        {
            var data = "{ \"fname\" : \"" + fname  + " \" , \"lastname\" : \"" + lastname + "\" }";
    //// you have to add the JsonRequestBehavior.AllowGet 
     //// otherwise it will throw an exception on run-time.
            return Json(data, JsonRequestBehavior.AllowGet);  
        }
