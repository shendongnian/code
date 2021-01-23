    using System.ComponentModel.DataAnnotations;
    class EmailValidationAttribute : RegularExpressionAttribute
    {
        public EmailValidationAttribute()
            : base("^[a-zA-Z0-9_\\+-]+(\\.[a-zA-Z0-9_\\+-]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9-]+)*\\.([a-zA-Z]{2,4})$") { }
    }
    class EmailTest
    {
        [EmailValidation(ErrorMessage="Please Enter a valid email address")]
        public String Email { get; set; }
    }
