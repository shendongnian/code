    public interface IRepository<T> where T : class
    {
        void DeserializeJSON();
    }
    
    public class Repository<T> : IRepository<T> where T : class
    {
        private string data;
        private List<T> entities;
    
        public void DeserializeJSON()
        {
                       // Cannot implicitly convert type
            entities = JsonConvert.DeserializeObject<List<T>>(data);
        }
    }
