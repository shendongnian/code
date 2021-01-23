    [Table("ShoppingCartItems")]
    public class ShoppingCartItem
    {
       //..
       [Display(Name = "Cart ID")]
       [ForeignKey("Shoppingcart")]
       public string cartID { get; set; }
       public virtual ShoppingCart Shoppingcart { get; set; }
    }
