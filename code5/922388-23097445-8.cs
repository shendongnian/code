    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Routing;
    public class BooksWriteController : ApiController
    {
        [PostRoute("api/Books")]
        public void Post() { }
    }
    
    [RoutePrefix("api/books")]
    public class BooksReadController : ApiController
    {
        [GetRoute("")]
        public void Get() { }
        
        [GetRoute("{id:int}")]
        public void Get(int id) { }
    }
