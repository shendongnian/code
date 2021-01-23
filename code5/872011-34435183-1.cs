    try
    {
        db.SaveChanges();
    }
    catch (DbEntityValidationException ex)
    {
        foreach (var entityValidationErrors in ex.EntityValidationErrors)
        {
            foreach (var validationError in entityValidationErrors.ValidationErrors)
            {
                Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
            }
        }
    }
