    public class StockQueriesController : ApiController
    {
        [ActionName("query1")]
        public HttpResponseMessage GetQuery1()
        {
            return new HttpResponseMessage() {Content = new StringContent("Query1")};
        }
        [ActionName("query2")]
        public HttpResponseMessage GetQuery2()
        {
            return new HttpResponseMessage() { Content = new StringContent("Query1") };
        }
        [ActionName("query3")]
        public HttpResponseMessage GetQuery3()
        {
            return new HttpResponseMessage() { Content = new StringContent("Query1") };
        }
        [ActionName("query4")]
        public HttpResponseMessage GetQuery4()
        {
            return new HttpResponseMessage() { Content = new StringContent("Query1") };
        }
    }
