    public ActionResult ChangePassword(Account account)
    {
        try
        {
                if (ModelState.IsValid)
                {
                    db.Accounts.Attach(account);
                    db.Entry(account).Property(x => x.Password).IsModified=true;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
        }
        catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
        {
            Exception raise = dbEx;
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    string message = string.Format("{0}:{1}",
                        validationErrors.Entry.Entity.ToString(),
                        validationError.ErrorMessage);
                    raise = new InvalidOperationException(message, raise);
                }
            }
            ModelState.AddModelError("", raise);
          
        } 
        return View(account);
    }
 
