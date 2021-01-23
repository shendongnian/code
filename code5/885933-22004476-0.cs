    public class Employee : IValidatableObject
    {
       public int Id { get; set; }
    
       [Required]
       [StringLength(50)]
       public string Name { get; set; }
       
       [Required]
       public string JobTitle { get; set; }
    
       [Required]
       public string Address { get; set; }
      
       [Required]
       [Phone]
       public string TelephoneNumber { get; set; }
       
       [Required]
       [EmailAddress]
       public string Email { get; set;
       public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
       {
           if (Id == 0)
           {
               yield return new ValidationResult("Employee Id must be greater than zero.", new [] { "Id" } );
           }
       }
    }
