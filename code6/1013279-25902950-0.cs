        using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
   
        public class Friend: IValidatableObject
    
        {
            [Required]
            public string Name { get; set; }
    
            public string Photo { get; set; }
    
            public Address Location { get; set; }
    
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                var results = new List<ValidationResult>();
    
                var isValid = Validator.TryValidateObject(this, validationContext, results);
    
                if (!isValid)
                {
                    foreach (var validationResult in results)
                    {
                        results.Add(validationResult);
                    }
                }
    
                return results;
            }
        }
     
 
    public class Address
    {
        public string Line1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
 
