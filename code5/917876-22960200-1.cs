    public class SignupModel
    {
        [Required]
        [Remote("IsAddressValid", "Validation")]
        public string Address{ get; set; }
    }
