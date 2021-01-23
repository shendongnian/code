    [HttpPost]
    public ActionResult UserPassword(UserChangePassword model)
    {
         var user= testdb.UserInfoes.Where(a => a.UserId.Equals(model.UserId)).FirstOrDefault();
                
         if (Session["UserPASS"] !=null&& ModelState.IsValid && model.OldPassword==user.Password)
         {
             user.Password=model.NewPassword;
             testdb.Entry(user).State = System.Data.Entity.EntityState.Modified;
             testdb.SaveChanges();
             Session["UserPass"] = model.NewPassword.ToString();
             return RedirectToAction("UserLogin");
         }
         else
         {
               //False section
         }   
    }
