    public class CartController
    {
       CartBLL cartBLL = new CartBLL();
       public ActionResult Index(int Id)
       {
           var cartDetails = cartBLL.GetCartDetails(Id);
           
           // Make a cartViewModel
           
           View(cartViewModel);
       }
    }
