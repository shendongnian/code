        /// <summary>
        /// Get called everytime  a Validation is triggered on an object. EG MVC model check or  EF save.
        /// </summary>
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            // Sample Implementation. 
            var validationResult = new List<ValidationResult>();
    
            // a field cant be null or empty when condition X is true.
            if ( SOME CONDTION that is true   ) {
              validationResult.Add(new ValidationResult(some field is required when...", new List<string>() {"FieldName"}));
              }
            return validationResult;
        }
