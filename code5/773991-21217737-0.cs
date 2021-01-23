    //The controller name relates to the route
        public class NQSaleController : ApiController
    {
    // The action name relates to the HttpVerb
        public IEnumerable<NQSaleDto> Get()
        {
            //return db.NQSales.AsEnumerable();
            return db.NQSales
                .AsEnumerable()
                .Select(nqlist => new NQSaleDto(nqlist));
    
        }
    }
