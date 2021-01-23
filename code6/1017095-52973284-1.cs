    public class MyController : ApiController
    {
        public IHttpActionResult Get()
        {
            string filePath = GetSomeValidFilePath();
            return new FileResult(filePath);
        }
    }
