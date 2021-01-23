    namespace Sample.Models
    {
        public class XModel
        {
            // ...
            [Required]  
            [GoogleReCaptchaValidation]  
            [BindProperty(Name = "g-recaptcha-response")]  
            public String GoogleReCaptchaResponse { get; set; }
        }
    }
