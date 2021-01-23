    public class ResetPasswordViewModel
    {
        public UserAccount UserAccount { get; set; }
        [Display(Name = "Retype Password", Prompt = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string RetypePassword { get; set; }
    }
