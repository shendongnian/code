    public Base64ValueSerializer : ValueSerializer
    {
      public override bool CanConvertToString(object value, IValueSerializerContext context)
      { 
         //If your value string contains a '\0' then base.CanConvertToString will return false
         //var canConvert = base.CanConvertToString(value, context); 
         return IsValidString(value);
      }
      private bool IsValidString(string input)
      {
         //Check if input string contains 'invalid' characters that can be converted
         //automatically to its HTML equivalent, like '\0' to '&#x0'
         bool isValid = ...
         return isValid;
      }
    }
