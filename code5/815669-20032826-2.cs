        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
        if (file != null && file.ContentLength > 0) 
        {
                int len =file.ContentLength;
                var myData = new byte[len];
                file.InputStream.Read(myData, 0, len);
                var fileId = SaveOrWriteToDb(file.FileName, file.ContentType, ref myData);
                if(fileId > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
        }
