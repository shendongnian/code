        public MaxLengthBilingualStringAttribute(int length) : base(length)
        {
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            BilingualString bilingualString = new BilingualString();
            if (value.GetType() == typeof(EdmBilingualStringVarCharSingleLine))
            {
                var bs = value as EdmBilingualStringVarCharSingleLine;
                bilingualString.English = bs.English;
                bilingualString.French = bs.French;
            }
            else
                return new ValidationResult("MaxLengthBilingualString Attribute does cannot be used with this type.");
            if (bilingualString.English != null && bilingualString.English.Length > this.Length )
                return new ValidationResult(string.Format("The maximum field length of {0} has been exceed for {1} English.", this.Length, validationContext.DisplayName));
            if (bilingualString.French != null && bilingualString.French.Length > this.Length)
                return new ValidationResult(string.Format("The maximum field length of {0} has been exceed for {1} French.", this.Length, validationContext.DisplayName));
            return ValidationResult.Success;
        }
    }
