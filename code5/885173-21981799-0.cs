    public static class WcfExt
    {
        public static Task<byte[]> DoSomethingAsync(
            this IMyService service,
            string someInputValue)
        {
            return Task.Factory.FromAsync(
                 (asyncCallback, asyncState) =>
                     service.BeginDoSomething(someInputValue, asyncCallback, asyncState),
                 (asyncResult) =>
                     service.EndDoSomething(asyncResult);
        }
    }
    public class PortalController : AsyncController 
    {
        public void NewsAsync(string someInputValue) {
    
            AsyncManager.OutstandingOperations.Increment();
            var myService = new MyService();
            myService.DoSomethingAsync(someInputValue).ContinueWith((task) =>
            {
                AsyncManager.Parameters["data"] = task.Result;
                AsyncManager.OutstandingOperations.Decrement();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    
        public ActionResult NewsCompleted(byte[] data) 
        {
            return View("News", new ViewStringModel
            {
                NewsData = data
            });
        }
    }
