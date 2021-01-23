    interface IValidationService
    {
        bool DoesPlaceExist(Place place);
    }
    
    class RedisValidationService : IValidationService
    {
        bool DoesPlaceExist(Place place)
        {
           // crazy redis magic ...
        }
    }
    class PlaceValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {    
           var validationService = new RedisValidationService();  // ideally use IoC
           var isValid = validationService.DoesPlaceExists(new Place(value)); 
           // ... this is over simplified to just show the idea
           // return blah blah 
        }
