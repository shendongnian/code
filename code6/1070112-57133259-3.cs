    namespace Sample.Validation
    {
        public class GoogleReCaptchaValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                Lazy<ValidationResult> errorResult = new Lazy<ValidationResult>(() => new ValidationResult("Google reCAPTCHA validation failed", new String[] { validationContext.MemberName }));
    
                if (value == null || String.IsNullOrWhiteSpace( value.ToString())) 
                {
                    return errorResult.Value;
                }
    
                IConfiguration configuration = (IConfiguration)validationContext.GetService(typeof(IConfiguration));
                String reCaptchResponse = value.ToString();
                String reCaptchaSecret = configuration.GetValue<String>("GoogleReCaptcha:SecretKey");
                
                HttpClient httpClient = new HttpClient();
                var httpResponse = httpClient.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={reCaptchaSecret}&response={reCaptchResponse}").Result;
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    return errorResult.Value;
                }
    
                String jsonResponse = httpResponse.Content.ReadAsStringAsync().Result;
                dynamic jsonData = JObject.Parse(jsonResponse);
                if (jsonData.success != true.ToString().ToLower())
                {
                    return errorResult.Value;
                }
    
                return ValidationResult.Success;
            }
        }
    }
    
