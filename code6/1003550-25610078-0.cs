    using System.ComponentModel.DataAnnotations; 
    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    [DisplayName("Email Address")]
    public String Email { get; set; }
