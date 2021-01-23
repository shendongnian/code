    public class ImageController : Controller
    {
        public ActionResult DislpayImage( int id )
        {
            var imageData = ...get bytes from database...
    
            return File( imageData, "image/jpg" );
        }
    }
