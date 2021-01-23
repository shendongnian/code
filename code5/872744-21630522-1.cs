    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public sealed class AddressRequiredAttribute : RequiredAttribute
    {
        private string _propertyName;
        public AddressRequiredAttribute(string propertyName)
            : base()
        {
            _propertyName = propertyName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (context.ObjectType.BaseType == typeof(AddressModel))
            {
                PropertyInfo property = context.ObjectType.GetProperty(_propertyName);
                if (property != null && (bool)property.GetValue(context.ObjectInstance))
                {
                    return base.IsValid(value, context);
                }
            }
            return ValidationResult.Success;
        }
    }
