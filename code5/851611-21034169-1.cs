    public class SharedImageController : Controller {
        
        public ActionResult GetImage(String imageId) {
            
            String uncPath = GetImageUncLocationFromId( imageId );
            
            Response.ContentType = "image/jpeg"; // change as appropriate
            return new FileResult( uncPath );
        }
    }
