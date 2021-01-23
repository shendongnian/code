    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    
    namespace LiteRemit.Models
    {
        [Table("customers")]
        public class CustomerModel
        {
            [Key]
            public int CustomerId { get; set; }
            public string Name { get; set; }
            public string Country { get; set; }
        }
    }
