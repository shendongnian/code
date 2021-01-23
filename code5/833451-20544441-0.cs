    public sealed class IsDateAfterAttribute: ValidationAttribute, IClientValidatable
      {
        protected abstract string GetValidationType();
        protected abstract bool CompareValues(DateTime value, DateTime propertyTestedValue, out ValidationResult validationResult);
    
        protected readonly string testedPropertyName;
        protected readonly bool allowEqualDates;
    
        protected int _maxSearchableDaysAhead;
    
        public IsDateAfterAttribute(string testedPropertyName, bool allowEqualDates = false)
        {
          this.testedPropertyName = testedPropertyName;
          this.allowEqualDates = allowEqualDates;
        }
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
          var propertyTestedInfo = validationContext.ObjectType.GetProperty(this.testedPropertyName);
          if (propertyTestedInfo == null)
          {
            return new ValidationResult(string.Format("unknown property {0}", this.testedPropertyName));
          }
    
          var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);
    
          if (value == null || !(value is DateTime))
          {
            return ValidationResult.Success;
          }
    
          if (propertyTestedValue == null || !(propertyTestedValue is DateTime))
          {
            return ValidationResult.Success;
          }
    
          ValidationResult returnVal;
          if (CompareValues((DateTime)value, (DateTime)propertyTestedValue, out returnVal))
          {
            return returnVal;
          }
          else
          {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
          }
          
    
          
        }
        
        protected override bool CompareValues(DateTime value, DateTime propertyTestedValue, out ValidationResult validationResult)
    {
      validationResult = null;
      // Compare values
      if (value <= propertyTestedValue)
      {
        if (this.allowEqualDates)
        {
          validationResult = ValidationResult.Success;
          return true;
        }
        if (value < propertyTestedValue)
        {
          validationResult = ValidationResult.Success;
          return true;
        }
        
      }
      
      return false;
    }
        
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
          
          this._maxSearchableDaysAhead = Setting.GetSettingValue(SettingNames.MaxSearchableDaysAhead, 548);
    
          var rule = new ModelClientValidationRule
          {
            ErrorMessage = string.Format(this.ErrorMessageString, _maxSearchableDaysAhead),
            ValidationType = "isdateafter"
          };
          rule.ValidationParameters["propertytested"] = this.testedPropertyName;
          rule.ValidationParameters["allowequaldates"] = this.allowEqualDates;
          yield return rule;
        }
      }
