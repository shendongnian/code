    public class LoginAndDateValidation : LoginValidation
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
    public class ViewModelA : LoginAndDateValidation
    {
        public string SomeOtherProperty { get; set; }
    }
