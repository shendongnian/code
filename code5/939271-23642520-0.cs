    public class MyController : ApiController
    {
        public Task Get()
        {
            // should be AspNetSynchronizationContext
            var context = SynchronizationContext.Current;
    
            return Task.FromResult(1)
                .ContinueWith(_ => { }, TaskSheduler.Default)
                .ContinueWith(_ =>
                {
                    object result;
                    context.Send(_ => result = Ok(DateTime.Now.ToLongTimeString(), 
                        null);
                    return result;
                }, TaskSheduler.Default);
        }
    }
