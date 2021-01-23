    using System.Data.Entity;
    using System.Security.Claims;
    using System.ComponentModel.DataAnnotations;
    namespace SO_GUI.Models
    {    
        public class BillingValidation
        {
            [Key]
            public string Section { get; set; }
            public string Details { get; set; }
            public string Total { get; set; }
        }    
    }
