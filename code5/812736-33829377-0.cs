    public interface IAddNumbersContract
    {
        [XmlRpcBegin("add_numbers")]
        IAsyncResult BeginAddNumbers(int x, int y, AsyncCallback acb);
    
        [XmlRpcEnd]
        int EndAddNumbers(IAsyncResult asyncResult);
    }
    
    public class AddNumbersCaller
    {
        public async Task<int> Add(int x, int y)
        {
            const int timeout = 5000;
            var service = XmlRpcProxyGen.Create<IAddNumbersContract>();
            var task = Task<int>.Factory.FromAsync((callback, o) => service.BeginAddNumbers(x, y, callback), service.EndAddNumbers, null);
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                return task.Result;
            }
    
            throw new WebException("It timed out!");
        }
    }
