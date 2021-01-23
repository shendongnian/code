    try
    {
        _context.SaveChanges();
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
