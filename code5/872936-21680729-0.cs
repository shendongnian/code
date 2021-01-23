    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        if (context.ObjectType.BaseType == typeof(AddressModel))
        {
            AddressModel model = (AddressModel)context.ObjectInstance;
            PropertyInfo property = typeof(AddressModel).GetProperty(_propertyName);
    
            bool isRequired = (bool)property.GetValue(model, null); 
            //OR YOU CAN INTERROGATE THE MODEL DIRECTLY
            var x = model.SomeProperty == true;
    
            return base.IsValid(value, context);
        }
    
        return ValidationResult.Success;
    }
