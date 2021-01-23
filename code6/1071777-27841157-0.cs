        using System.ComponentModel.DataAnnotations;
        using System.Web;
        
        namespace MyProject.Models
        {
            public class MemberModel 
            {
        
                [Required]
                public string Name { get; set; }
        
                [Required]
                [EmailAddress]
                public string Email { get; set; }
                
                [Required]
                public string Password { get; set; }
            }
    }
