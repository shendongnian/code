    [MetadataType(typeof(MyModelMetadata ))]
    public class ContactUsFormModel : AddressModel
    {
        [DisplayName("Title")]
        [StringLength(5)]
        public string Title { get; set; }
        [DisplayName("First name (required)")]
    
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(50, ErrorMessage = "Please limit your first name to {1} characters.")]
        public string FirstName { get; set; }
    
        // etc...
    }
    internal class MyModelMetadata {
        [Required]
        public string SomeProperyOfModel { get; set; }
    }
