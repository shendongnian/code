    public class FoosController : ODataController
    {
        // GET odata/Foos
         [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(FakeData.Instance.Foos.AsQueryable());
        }
    }
