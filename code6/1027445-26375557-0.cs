    public class Controller : ApiController
    {
        public Task<string> GetAsync()
        {
            var repository = new Repository();
            return repository.GetItemAsync();
        }
    }
