     [HttpPost]
    public async Task<ActionResult> UpdateRegisteration(ApplicationUser UpdatedUser)
    {
        var SavedUser = await UserManager.FindByIdAsync(UpdatedUser.Id);
        try
        {
            UpdatedUser.SecurityStamp = SavedUser.SecurityStamp;
            UpdatedUser.PasswordHash = SavedUser.PasswordHash;
            UpdatedUser.UserName = SavedUser.UserName;
            UpdatedUser.Id = SavedUser.Id;
            UpdatedUser.PersonalInfo.ID = SavedUser.PersonalInfo.ID;
            UpdatedUser.BillingInfo.ID = SavedUser.BillingInfo.ID;
            UpdatedUser.DeliveryInfo.ID = SavedUser.DeliveryInfo.ID;
            ApplicationDbContext db = new ApplicationDbContext();
            db.Entry(UpdatedUser).State = EntityState.Modified;
            db.Entry(UpdatedUser.PersonalInfo).State = EntityState.Modified;
            db.Entry(UpdatedUser.BillingInfo).State = EntityState.Modified;
            db.Entry(UpdatedUser.DeliveryInfo).State = EntityState.Modified;
            await db.SaveChangesAsync();
            //            var result = await UserManager.UpdateAsync(SavedUser);
            return RedirectToAction("Index", "Home");
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
                    // raise a new exception nesting
                    // the current instance as InnerException
                    raise = new InvalidOperationException(message, raise);
                }
            }
            throw raise;
        }
    }
