    public class HomeController : Controller
    	{
    		public ActionResult Index()
    		{
    			return View();
    		}
    
    		[HttpPost]
    		public WrappedJsonResult UploadImage(HttpPostedFileWrapper imageFile)
    		{
    			if (imageFile == null || imageFile.ContentLength == 0)
    			{
    				return new WrappedJsonResult
    				{
    					Data = new
    					{
    						IsValid = false,
    						Message = "No file was uploaded.",
    						ImagePath = string.Empty
    					}
    				};
    			}
    
    			var fileName = String.Format("{0}.jpg", Guid.NewGuid().ToString());
    			var imagePath = Path.Combine(Server.MapPath(Url.Content("~/Uploads")), fileName);
    
    			imageFile.SaveAs(imagePath);
    
    			return new WrappedJsonResult
    			{
    				Data = new
    				{
    					IsValid = true,
    					Message = string.Empty,
    					ImagePath = Url.Content(String.Format("~/Uploads/{0}", fileName))
    				}
    			};
    		}
    	}
