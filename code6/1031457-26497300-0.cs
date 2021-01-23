    public class Order
    {
        public int ID {get; set;}
    
        [Required]
        public int Total {get; set;}    
    
        [Required]
        public int ProductId{get; set;}
        [Required]
        public virtual Product Product { get; set; }
    }
