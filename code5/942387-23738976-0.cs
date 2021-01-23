        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resource resource, HttpPostedFileBase FileUpload1)
        {
            //verify file that file exist
            if (fFileUpload1 != null && FileUpload1.ContentLength > 0)
            {
                //get filename
                var fileName = Path.GetFileName(FileUpload1.FileName);
                //store file in speficied folder
                var path = Path.Combine(Server.MapPath("~/Catalog/Uploads"), fileName);
               FileUpload1.SaveAs(path);
            }
            if (ModelState.IsValid)
            {
                db.Resources.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resource);
        }
