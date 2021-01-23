    public abstract class MyBaseController : Controller
    {
        public virtual void Create() 
        {
            //standard implementation
        }
    }
    public class SEOController : MyBaseController 
    {
        public override void Create()
        {
            //specific to SEO
        }
     }
