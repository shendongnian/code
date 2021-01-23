    public interface ICentralService
    {
        // Just use .ContinueWith to call a completion method
        Task<int> WorkItAsync(int x);
    }
    
    public class CentralService : ICentralService 
    {
        private IMyService _Srv;
        public CentralService(IMyService srv) 
        {
            _Srv = srv;
        }
        public Task<int> WorkItAsync(int x) 
        {
            // Callback is handled in ViewModel using ContinueWith
            return Task<int>.Factory.FromAsync(_Src.BeginTest, _Src.EndTest, x);
        }
    }
    
    public class SomeViewModel : INotifyPropertyChanged 
    {
        private ICentralService _Central;
    
        public SomeViewModel(ICentralService central)
        {
            _Central = central;
        }
    
        private void A()
        {
            _Central.WorkItAsync(5)
                    .ContinueWith(prevTask =>
                    {
                        // Handle or throw exception - change as you see necessary
                        if (prevTask.Exception != null)
                            throw prevTask.Exception;
    
                        // Do something with the result, call another method, or return it...
                        return prevTask.Result;
                    });
        }
    }
