    try
    { ... }
    catch (DbEntityValidationException exception)
    {
      foreach (DbEntityValidationResult validationErrors in exception.EntityValidationErrors)
      {
        foreach (DbValidationError validationError in validationErrors.ValidationErrors)
        {
          string log = string.Format("{0} - {1}",
          validationError.PropertyName, validationError.ErrorMessage);
        }
      }
    }
