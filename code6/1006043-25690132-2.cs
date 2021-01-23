    //
    // POST: /Account/Profile
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult UserProfile(UserProfile model)
    {
        string hashCheckVal = MyHashHelper.CalculateMD5Hash(model.UserID + model.UserName + model.SomeSetting)
        if(string.Compare(hashCheckVal, model.SecurityHash) != 0)
        {
            throw new Exception("tampered with!");
        }
        // if I dont include UserName, validation will fail since it 
        // is now null and the field is [Required]
        if (ModelState.IsValid)
        {
            // if I dont include hidden fields, UserId, UserName
            // and SomeSetting will be null here
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
        return View(model);
    }
