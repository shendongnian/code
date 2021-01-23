    public class MyClass
    {
        // this constant could also be placed inside a resx file.
        const string RequiredFieldString = "{0} is a required field.";
        [Display(Name = "First name")]
        [Required(ErrorMessage = RequiredFieldString)]
        public string FirstName { get; set; }
        // Validating this will give you "First name is a required field."
        // So you can reuse the constant string.
    }
