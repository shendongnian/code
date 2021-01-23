    public class RegisterViewModel
    {
        [CustomValidation(typeof(CustomValidations), "ValidatePassword")]
        public string Password { get; set; }
    }
