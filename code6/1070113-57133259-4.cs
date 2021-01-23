    namespace Sample.Models
    {
        public class XModel
        {
            // ...
            [Required]  
            [GoogleReCaptchaValidation]  
            public String GoogleReCaptchaResponse { get; set; }
        }
    }
