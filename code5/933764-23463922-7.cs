    namespace Store.Models
    {
        using System;
        using System.Collections.Generic;
        public partial class Invoice
        {
             public Invoice()
             {
                 this.Products = new HashSet<Product>();
             }
            public int Id { get; set; }
            public string Details { get; set; }
            public Nullable<decimal> Total { get; set; }
            
            [NotMapped]
            public int Age {get; set;
        // ...
