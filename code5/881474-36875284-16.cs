    namespace WebApplication1.Controllers {
    	public class FanController : Controller {
    		public ActionResult Index() {
    			ModelState.SetModelValue( "FavouriteMusic", new ValueProviderResult( string.Empty, string.Empty, System.Globalization.CultureInfo.InvariantCulture ) );
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
