    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
    {
        foreach (var validationErrors in ex.EntityValidationErrors)
        {
            foreach (var validationError in validationErrors.ValidationErrors)
            {
                Console.WriteLine("Property: {0} throws Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
            }
        }
    }
