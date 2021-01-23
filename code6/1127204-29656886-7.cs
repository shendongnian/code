    [Table("ShoppingCartItems")]
    public class ShoppingCartItem
    {
       //..
       [Display(Name = "Cart ID")]
       public string cartID { get; set; }
      
       [ForeignKey("cartID")]
       public virtual ShoppingCart Shoppingcart { get; set; }
    }
