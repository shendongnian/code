    private void Validate()
    {
    	validators = GetType()
    					// get all the properties
    					.GetProperties()
    					// where there are validation attributes
    					.Where(p => GetValidations(p).Length !=  0)
    					// and return a dictionary with the name of the property
    					// and an array of validation attributes
    					.ToDictionary(p => p.Name, p => GetValidations(p));
    	
    	propertyGetters = GetType()
    					// get all the properties
    					.GetProperties()
    					// where there are validation attributes
    					.Where(p => GetValidations(p).Length != 0)
    					// and return a dictionary with the name of the property
    					// and a method which calls the getter of that property
    					.ToDictionary(p => p.Name, p => GetValueGetter(p));
    }
    
    /// <summary>
    /// Gets a list of validation attributes for supplied property
    /// </summary>
    private ValidationAttribute[] GetValidations(PropertyInfo property)
    {
    	return (ValidationAttribute[])
    				property.GetCustomAttributes(
    					typeof(ValidationAttribute), 
    					true);
    }
    
    /// <summary>
    /// Get the getter for the supplied property
    /// </summary>
    private Func<ValidationBase, object> GetValueGetter(PropertyInfo property)
    {
    	return viewmodel => property.GetValue(viewmodel, null);
    }
