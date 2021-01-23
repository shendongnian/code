    public class Service1 : IService1
    {
        public Task<int> GetEmpIdAsync(int id)
        {
            return Task.FromResult<int>(id);
        }
    }
