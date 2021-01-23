    public class EmailModel
    {
        [RequiredArray(ErrorMessage = "At least one email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string[] EmailAddresses { get; set; }
    }
