    [HttpGet]
    public ActionResult Log() {         
         try {
            string content = string.Empty;
            using (var stream = new StreamReader(Server.MapPath("~/Views/Builder/TestLogger.txt"))) {
              content = stream.ReadToEnd();
            }
            return Content(content);
         }
         catch (Exception ex) {
           return Content("Something ");
         }
    } 
