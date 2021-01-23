    public enum ComparisonType
    {
        LessThan,
        LessThanOrEqual,
        Equal,
        GreaterThanOrEqual,
        GreaterThan,
        NotEqual
    }
    public sealed class ComparisonAttribute : ValidationAttribute
    {
        string PropertyToCompare { get; set; }
        ComparisonType Type { get; set; }
        public ComparisonAttribute(string propertyToCompare, ComparisonType type)
        {
            PropertyToCompare = propertyToCompare;
            Type = type;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance == null || value == null)
                return new ValidationResult("Cannot compare null values");
            PropertyInfo property = validationContext.ObjectType.GetProperty(PropertyToCompare);
            object propertyValue = property.GetValue(validationContext.ObjectInstance, null);
            string errorMessage = "";
            if (value is IComparable)
            {
                int compVal = ((IComparable)value).CompareTo(propertyValue);
                switch (Type)
                {
                    case ComparisonType.LessThan:
                        errorMessage = compVal < 0 ? "" : string.Format("{0} is not less than {1}", validationContext.DisplayName, property.Name);
                        break;
                    case ComparisonType.LessThanOrEqual:
                        errorMessage = compVal <= 0 ? "" : string.Format("{0} is not less than or equal to {1}", validationContext.DisplayName, property.Name);
                        break;
                    case ComparisonType.Equal:
                        errorMessage = compVal == 0 ? "" : string.Format("{0} is not equal to {1}", validationContext.DisplayName, property.Name);
                        break;
                    case ComparisonType.GreaterThanOrEqual:
                        errorMessage = compVal >= 0 ? "" : string.Format("{0} is not greater than or equal to {1}", validationContext.DisplayName, property.Name);
                        break;
                    case ComparisonType.GreaterThan:
                        errorMessage = compVal > 0 ? "" : string.Format("{0} is not greater than {1}", validationContext.DisplayName, property.Name);
                        break;
                    case ComparisonType.NotEqual:
                        errorMessage = compVal != 0 ? "" : string.Format("{0} cannot be equal to {1}", validationContext.DisplayName, property.Name);
                        break;
                    default:
                        errorMessage = "";
                        break;
                }
            }
            if (String.IsNullOrEmpty(errorMessage))
                return ValidationResult.Success;
            return new ValidationResult(errorMessage);
        }
    }
