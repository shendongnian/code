    public override int SaveChanges()
    {
        try
        {
            base.SaveChanges();
        }
        catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
        {
            Exception exception = dbEx;
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    string message = string.Format("{0}:{1}", 
                        validationErrors.Entry.Entity.ToString(),
                        validationError.ErrorMessage);
                    //create a new exception inserting the current one
                    //as the InnerException
                    exception = new InvalidOperationException(message, exception);
                }
            }
            throw exception;
        }
    }
