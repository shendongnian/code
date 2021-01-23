    public class ImagesController: Controller
    {
        public ActionResult Index(int id)
        {
            byte[] imageData = ... go get your image data from the id
            return File(imageData, "image/png"); // Might need to adjust the content type based on your actual image type
        }
    }
