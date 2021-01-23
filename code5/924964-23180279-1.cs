    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace MvcApplication2.Models
    {
        public class ShopItem
        {
            public int? Id { get; set; }
            public string Name { get; set; }
            public decimal? Cost { get; set; }
    
            public ShopItem()
            {
                Id = null;
                Name = "";
                Cost = null;
            }
        }
    }
