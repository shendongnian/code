      public partial class XContent
        {
            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessageResourceName = "UseLettersOnly", ErrorMessageResourceType = typeof(Resource))]
            public string FullName { get; set; }
    }
