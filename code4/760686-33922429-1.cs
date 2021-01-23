    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    namespace Web.ProjectName.Models
    {
        public class ContactForm
        {
            ...
            [Required]
            [Display(Name = "State")]
            [RegularExpression("[A-Z]{2}")]
            public string State { get; set; }
            
            ...
            
        }
    }
