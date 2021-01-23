    public class CategoryController : ApiController
    {
        public IEnumerable<Category> Get() 
        {
            ...
        }
        public Category Get(int id) 
        {
            ...
        }
        [HttpGet]
        public IEnumerable<QuestionSummary> Questions(int categoryId) 
        {
            ...
        }
    }
