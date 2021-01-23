    public interface IHandler
    {
        Task Success();
        void Error();
    }
    
    public class Handler1 : IHandler
    {
        public Task Success()
        {
            Provider.Page.text = "hello";
            return Task.FromResult<object>(null); 
        }
        public void Error() {}
    }
    public class Handler2 : IHandler
    {
        public async Task Success()
        {
            return Provider.OperationAsync();
        }
        public void Error() {}
    }
