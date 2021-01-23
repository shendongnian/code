    namespace WebApplication1.Controllers {
    	public class FanController : Controller {
    		public ActionResult Index() {
    			ModelState.Add( "FavouriteMusic", new System.Web.Mvc.ModelState() { Value = new ValueProviderResult( string.Empty, string.Empty, System.Globalization.CultureInfo.InvariantCulture ) } );
    			return View( "Index" );
    		}
    		[HttpPost, ActionName( "Index" )]
    		public ActionResult Register( Models.Fan newFan ) {
    			if( !ModelState.IsValid )
    				return View( "Index" );
    			ModelState.Clear();
    			ViewBag.Message = "OK - You may register another fan";
    			return Index();
    		}
    	}
    }
