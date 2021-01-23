    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(User user, HttpPostedFileBase file)
    {
                
                    // TODO: Add insert logic here
                user.Pictuer = FileUpload.UploadFile(file);
                        db.User.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    
                
     }
