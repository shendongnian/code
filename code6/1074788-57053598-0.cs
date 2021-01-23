    [Table("Cart")]
    public class ShopingCart
    {
       [Key]
       public int Id { get; set; }
 
       public DateTime CreatedDate { get; set; }
       public virtual ICollection<ItemCart> Products { get; set; } // relationship one-to-many
    }
