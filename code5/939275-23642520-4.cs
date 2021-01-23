    public class MyController : ApiController
    {
        public Task Get()
        {
            // should be AspNetSynchronizationContext
            var context = SynchronizationContext.Current;
    
            return Task.FromResult(1)
                .ContinueWith(_ => { }, TaskScheduler.Default)
                .ContinueWith(_ =>
                {
                    object result = null;
                    context.Send(__ => { result = Ok(DateTime.Now.ToLongTimeString()); }, 
                        null);
                    return result;
                }, TaskScheduler.Default);
        }
    }
