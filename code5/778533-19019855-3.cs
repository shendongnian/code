    [HttpPost]
    public ActionResult FileUpload(HttpPostedFileBase uploadFile) // OR IEnumerable<HttpPostedFileBase> uploadFile
    {
        //For checking purpose 
         HttpPostedFileBase File = Request.Files["uploadFile"];
        if (File != null)
        {
            //If this is True, then its Working.,
        }
        if (uploadFile.ContentLength > 0)
        {
            string filePath = Path.Combine(HttpContext.Server.MapPath("../Uploads"),
                                           Path.GetFileName(uploadFile.FileName));
            uploadFile.SaveAs(filePath);
        }
        return View();
    }
