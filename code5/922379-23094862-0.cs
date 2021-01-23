    public class BooksWriteController : EventStoreApiController
    {
        [Route("api/Books")]
        public void Post([FromBody] CommandWrapper commandWrapper){...}
    }
    
    public class BooksReadController : MongoDbApiController
    {
        [Route("api/Books")]
        public TaskTypeInfo[] Get() {...}
    
    
        [Route("api/Books/{id:int}")]
        public TaskTypeInfo Get(int id) {...}
    }
