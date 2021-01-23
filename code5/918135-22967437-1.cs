    public ActionResult Submit(IEnumerable<HttpPostedFileBase> files)
            {
                if (files != null)
                {
                    TempData["UploadedFiles"] = GetFileInfo(files);
                }
    
                return RedirectToAction("Result");
            }
    
            public ActionResult Result()
            {
                return View();
            }
    
            private IEnumerable<string> GetFileInfo(IEnumerable<HttpPostedFileBase> files)
            {
                return
                    from a in files
                    where a != null
                    select string.Format("{0} ({1} bytes)", Path.GetFileName(a.FileName), a.ContentLength);
            }
