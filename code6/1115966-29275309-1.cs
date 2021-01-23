    [HttpPost]
        public ActionResult Create(tblBanner tblbanner)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    tblbanner.ImagePath = clsUploadFile.uploadFile(Request.Files[0], "/Content/BannerImages/");
                }
                
                db.tblBanners.AddObject(tblbanner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblbanner);
        }
