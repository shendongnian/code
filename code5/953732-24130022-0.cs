    public class QueryObject
    {
        public string id { get; set; } 
        public DateTime orderDate { get; set; }
        public string status { get; set; }
        // etc
    }
    public OrderController : ApiController
    {
        public HttpResponseMessage Get([FromUri] QueryObject query) 
        {
             // some method (possibly uses Linq)that acts on your filters
             FilteredGet(query.id, query.orderDate, query.status);
        }
    }
