    public class CartController {
       
       // controller action
       [HttpGet]
       public void addToCart(string item, int quantity)
       {
          return "Your cart now contains: " + quantity + " " + itemName;
          // You may do something else
       }
    }
