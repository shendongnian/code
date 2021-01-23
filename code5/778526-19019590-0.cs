    [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FileUpload(FormCollection formData)
        {
            HttpPostedFileBase file = null;
            try
            {
                file = Request.Files[0];
            }
            catch { }
            if (file != null && file.ContentLength > 0)
            {
                // upload successful... save the file (file.SaveAs(...))
            }
            else
            {
                // file not found... do something.
            }
            return View();
        }
