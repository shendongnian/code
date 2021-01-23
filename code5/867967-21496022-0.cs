    public class HomeController : Controller
     {
        public async Task<ActionResult> Index()
        {
        ViewBag.Message = await ProcessRequest();
        
        return View();
        }
        
        
        //TResult -> can be of any built-in or custom type that you should decide.
        Task<TResult> ProcessRequest()
        {
        
        // Make a TaskCompletionSource so we can return a puppet Task
        TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>();
        
        // Call your sync API method
        SyncAPI syncApi = new SyncAPI();
        
        // Call api method and set the result or exception based on the output from the API //method.
        tcs.SetResult(TResult);
        
        // Return the puppet Task, which isn't completed yet
        return tcs.Task;
        }
    }
