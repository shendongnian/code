      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                var results = new List<ValidationResult>();
    
                if (//some checks)
                {
                    results.Add(new ValidationResult("Some Message",
                                                     new[] {"TheNameOfTheProperty"}));
                }
    
                return results;
            }
