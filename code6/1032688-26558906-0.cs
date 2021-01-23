    using System;
    using System.ComponentModel.DataAnnotations;
    namespace YourProjectName.Models
    {
        public class CustomerMetadata
        {
            [Required]
            public virtual int CustomerId { get; set; }
            [Required]
            [StringLength(15)]
            public virtual string CompanyName { get; set; }
            
        }
    }
