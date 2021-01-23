    public class MyClass
    {
        [Display(ResourceType = typeof(Strings), Name = "FirstName")]
        [Required(ErrorMessageResourceName = "FieldRequired",
                  ErrorMessageResourceType = typeof(Strings))]
        public string FirstName { get; set; }
        [Required(ErrorMessageResourceName = "FieldRequired",
                  ErrorMessageResourceType = typeof(Strings))]
        public string MiddleName { get; set; }
        [Display(ResourceType = typeof(Strings), Name = "LastName")]
        [Required(ErrorMessageResourceName = "FieldRequired",
                  ErrorMessageResourceType = typeof(Strings))]
        public string LastName { get; set; }
        // Validation errors for culture [en] would be:
        //             "First name is a required field."
        //             "MiddleName is a required field."
        //             "Last name is a required field."
        //
        // Validation errors for culture [nl] would be:
        //             "Voornaam is een benodigd veld."
        //             "MiddleName is een benodigd veld."
        //             "Achternaam is een benodigd veld."
    }
