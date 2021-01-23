    public class productController : Controller
    {
        
        public void redirectAwsome()
        {
            Response.Redirect("http://mydomain.wordpress.com/product/awesome-thing ");
        }
        public void redirectAnother()
        {
            Response.Redirect("http://mydomain.wordpress.com/product/another-thing");
        }
    }
