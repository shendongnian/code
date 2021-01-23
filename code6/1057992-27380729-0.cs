    [RoutePrefix("api")]
    public class DataController : ApiController
    {
        [Route("company")]
        public IEnumerable<CompanyViewModel> GetCompanies() 
        {
        ....
        }
    }
