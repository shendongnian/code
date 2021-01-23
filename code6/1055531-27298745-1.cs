	private void Validate()
	{
        var properties = GetType().GetProperties();
		var propertiesWithValidators = (from property in properties
									   let validations = property.GetValidations(property)
									   where validations.Any()
									   select 
									   new 
									   { 
										   Property = property, 
										   Validations = validations 
									   }).ToArray();
		validators = propertiesWithValidators.ToDictionary(
						pwv => pwv.Property.Name, 
						pwv => pwv.Validations);
		
		propertyGetters = propertiesWithValidators.ToDictionary(
							pwv => pwv.Property.Name, 
							pwv => GetValueGetter(pwv.Property));
	}
