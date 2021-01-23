    public class MyModel
    {
        [Required]
        [DisplayName("Property Name")]
        [Range(0, 9999999, ErrorMessage = "Please enter a number between 0 and 9999999")]
        public int? PropName { get; set; }
    }
