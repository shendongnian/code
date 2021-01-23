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
            
            var attribute = (PostalCodeAttribute)postalCodeProperty.GetCustomAttribute(typeof(PostalCodeAttribute));
            
            if(attribute is USPostalCodeAttribute)
            {
                return ValidateUsPostalCode(model);
            }
            else if(attribute is GBPostalCodeAttribute)
            {
                return ValidateGBPostalCode(model);
            }
            else
            {
                throw new NotSupportedException("This country's postal code is not supported");
            }
        }
        
        public bool ValidateUsPostalCode(IPostalCodeModel model)
        {
            var regex = _regularExpressionService.GetPostalCodeRegex("en-US");
            return Regex.IsMatch(model.PostalCode, regex);
        }
        
        public bool ValidateGBPostalCode(IPostalCodeModel model)
        {
            var regex = _regularExpressionService.GetPostalCodeRegex("en-GB");
            return Regex.IsMatch(model.PostalCode, regex);
        }
    }
