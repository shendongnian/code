    change your entity 
    [DisplayName("Vanity URL")]
    [Remote("IsVanityURL_Available", "Validation",AdditionalFields = "VanityURL")]
    [RegularExpression(@"(\S)+", ErrorMessage = "White space is not allowed.")]
    [Editable(true)]               
    public string VanityURL { get; set; }
