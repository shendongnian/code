    try
    {
        //Your code
    }
    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
    {
    	var mrrorMessage = ex.EntityValidationErrors.ToList()[0].ValidationErrors.ToList()[0].ErrorMessage;
    	var propertyName = ex.EntityValidationErrors.ToList()[0].ValidationErrors.ToList()[0].PropertyName;
    }
    catch (Exception ex)
    {
        //other error
    	throw ex;
    }
