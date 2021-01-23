    [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase uploadFile)
        {
            if (uploadFile.ContentLength > 0)
            {
                // do something 
                // as example try to save file somewhere uploadFile.SaveAs(somewhere);
            }
            return View();
        }
