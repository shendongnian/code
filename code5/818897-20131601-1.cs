    public class ImagesController : Controller
    {
        public ActionResult Index(string id)
        {
            try
            {
               return File(id, "application/octetstream");
            }
            catch (FileNotFoundException)
            {
                // do 404 error stuff
            }
            catch (Exception)
            {
                // do generic error stuff
            }
        }
    }
