    public abstract class MyBaseController : Controller
    {
        public virtual void Create() 
        {
            //standard implementation
        }
    }
    public class SEOController : BaseClass
    {
        public override void Create()
        {
            //specific to SEO
        }
     }
