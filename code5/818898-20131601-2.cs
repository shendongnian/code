    public class ImagesController : Controller
    {
        public FileResult Index(string id)
        {
            try
            {
               return File(id, "application/octetstream", Path.GetFileName(id));
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
