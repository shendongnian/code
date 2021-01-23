    public class ItemsController : ApiController
    { 
        [Route("api/{controller}/{id}")]
        public string GetItemById(int id)
        {
             // Find item here ...
             return item.ToString();
        }
        [Route("api/{controller}/{name}/{id}")]
        public string GetItemByNameAndId(string name, int id)
        {
             // Find item here ...
             return item.ToString();
        }
    }
