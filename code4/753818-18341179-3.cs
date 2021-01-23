    public class PostalCodeValidator
    {
        private readonly IRegularExpressionService _regularExpressionService;
        
        public PostalCodeValidator(IRegularExpressionService regularExpressionService)
        {
            _regularExpressionService = regularExpressionService;
        }
    
        public bool IsValid(IPostalCodeModel model)
        {
            var postalCodeProperty = model.GetType().GetProperty("PostalCode");
            
            var attribute = postalCodeProperty.GetCustomAttribute(typeof(PostalCodeAttribute)) as PostalCodeAttribute;
            
            // Model doesn't implement PostalCodeAttribute
            if(attribute == null) return true;
            
            return ValidatePostalCode(_regualrExpressionService, model, attribute.Country);
        }
        
        private static bool ValidatePostalCode(
            IRegularExpressionService regularExpressionService,
            IPostalCodeModel model,
            string country
        )
        {
            var regex = regularExpressionService.GetPostalCodeRegex(country);
            return Regex.IsMatch(model.PostalCode, regex);
        }
    }
