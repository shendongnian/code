    public class MyClass
    {
        // this constant could also be placed inside a resx file.
        const string RequiredFieldString = "{0} is a required field.";
        [Display(Name = "First name")]
        [Required(ErrorMessage = RequiredFieldString)]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        [Required(ErrorMessage = RequiredFieldString)]
        public string LastName { get; set; }
        // Validation errors would be:
        //             "First name is a required field."
        //             "Last name is a required field."
    }
