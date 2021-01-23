    public class ApiTestController : ApiController
    {
        public IEnumerable<Image> GetImages()
        {
            return yourDataAccess.GetAllImages()                            
        }
    }
