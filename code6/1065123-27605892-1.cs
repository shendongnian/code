     [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Create([Bind(Include = "FilID,file,BildInfo")] Imagefiles imagefiles, HttpPostedFileBase imagesfiles)
                {
                    if (ModelState.IsValid)
                    {
                        db.Imagefiles.Add(imagefiles);
                        db.SaveChanges();
                            
                        var path = Path.Combine(Server.MapPath("~/Content/Files/"), imagesfiles.FileName);
        
                        var data = new byte[imagesfiles.ContentLength];
                        imagesfiles.InputStream.Read(data, 0, imagesfiles.ContentLength);
        
                        using (var sw = new FileStream(path, FileMode.Create))
                        {
                           sw.Write(data, 0, data.Length);
                         }
        
                        return RedirectToAction("Index");
                    }
                    else
                    {
                      //Message to the user
                    }
               }
