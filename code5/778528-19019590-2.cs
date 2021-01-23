        //Model (for instance I've created it inside controller, you can place it in model
        public class uploadFile
        {
            public HttpPostedFileBase file{ get; set; }
        }
        //Action
        public ActionResult Index(uploadFile uploadFile)
        {
            if (uploadFile.file.ContentLength > 0)
            {
                string filePath = Path.Combine(HttpContext.Server.MapPath("../Uploads"),
                                               Path.GetFileName(uploadFile.file.FileName));
                uploadFile.file.SaveAs(filePath);
            }
            return View();
        }
