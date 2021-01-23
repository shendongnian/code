        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                Validator.TryValidateProperty(property.GetValue(this), new ValidationContext(this, null, null) { MemberName = property.Name }, results);
                if (results.Count > 0)
                {
                    foreach (ValidationResult err in results)
                    {
                        yield return new ValidationResult(err.ErrorMessage);
                    }
                    results.Clear();
                }
            }
            //the rest of the validation happens here...
        }
