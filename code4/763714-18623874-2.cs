    public class CartBLL
    {     
      CartDAL cartDAL = new CartDAL();
      public CartDetails GetCartDetails(int cartId)
      {
         var cartDetails = new CartDetails();
         cartDetails.CartItems = cartDAL.GetCart(cartId);
         cartDetails.Tax = cartDAL.GetCart(cartId);
         cartDetails.Total = cartDAL.GetCart(cartId); 
         return cartDetails;
      }
    }
