    public class ItemsController : ApiController
    {
        public string GetItemById(int id)
        {
             // Find item here ...
             return item.ToString();
        }
        public string GetItemByNameAndId(string name, int id)
        {
             // Find item here ...
             return item.ToString();
        }
    }
