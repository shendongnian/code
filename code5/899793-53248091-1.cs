    try
    {
        //Your code
    }
    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
    {
    	var errorMessage = ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
    	var propertyName = ex.EntityValidationErrors.First().ValidationErrors.First().PropertyName;
    }
    catch (Exception ex)
    {
        //other error
    	throw ex;
    }
