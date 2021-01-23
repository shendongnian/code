    using System.ComponentModel.DataAnnotations;
    public class YourViewModel
        {
            [Required]
            [Range(0, 15, ErrorMessage = "Can only be between 0 .. 15")]
            public int stNumber { get; set; }
        }
