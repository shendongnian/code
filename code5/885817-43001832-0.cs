    public class VisitorAgreementTermViewModel
    {
        [Required]
        [Display(Name = "Message Accept.")]
        //[Range(typeof(bool), "true", "true", ErrorMessage = "Error Message Text.")]
        [RegularExpression("True", ErrorMessage = "Error Message Text.")]
        public bool Agreement { get; set; }
    }
