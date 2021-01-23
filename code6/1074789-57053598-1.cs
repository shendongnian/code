    [Table("ItemCart")]
    public class ItemCart
    {
       [Key]
       public int Id { get; set; } 
       public int Quantity { get; set; }
       public virtual Product Product { get; set; } // relationship one-to-one
    }
    
