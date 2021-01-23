      public ActionResult AddImage(Brand model,HttpPostedFileBase image1)
            {
                var db = new H_Cloths_SaloonEntities();
                if (image1!=null)
                {
    
                    model.Brandimage = new byte[image1.ContentLength];
                    image1.InputStream.Read(model.Brandimage,0,image1.ContentLength);
                }
                db.Brands.Add(model);
                db.SaveChanges();
                ViewBag.Path = "image uploaded Successfully...!";
                return View(model);
    
            }
