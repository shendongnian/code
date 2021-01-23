    public class UniqueAttribute : ValidationAttribute
    {
        public UniqueAttribute(Type entityType, string propertyName)
        {
            _entityType = entityType;
            _propertyName = propertyName;
        }    
        private Type _entityType;
        private string _propertyName;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Context db = new Context();
            foreach (var item in db.GetTable(_entityType).ToList())
            {
               if (value.Equals(GetPropertyValue(item, _propertyName))
               {
                   return new ValidationResult(validationContext.DisplayName + " is already taken.");
               }
            }
            return null;
        }
        private object GetPropertyValue(object item, string propertyName)
        {
            var type = item.GetType();
            var propInfo = type.GetProperty(propertyName);
            return (propInfo != null) ? propInfo.GetValue(value, null) : null;
        }
    }
