    public class ShoppingCartProduct
    { 
        [Key] 
        [Column (Order=1)]
        public int ID { get; set; }
    
        [Key]
        [Column(Order = 2)]
        public int ProductID { get; set; }
    }
