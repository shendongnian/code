        public class Product
        {
            public int ModelId { get; set; }
            public int ModelNumber { get; set; }
	        public int WarrantyId {get;set;}
            [ForeignKey("WarrantyId ")]
            public virtual Warranty Warranty { get; set; }
        }
	
