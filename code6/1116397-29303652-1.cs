        protected override async void OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
        {
            if (frame.IsMain)
            {
                // MAIN CALL TAKES PLACE HERE
                string HTMLsource = await browser.GetSourceAsync();
                Console.WriteLine("END: {0}, {1}", browser.GetMainFrame().Url, httpStatusCode);
            }
        }
    public class TaskStringVisitor : CefStringVisitor
    {
        private readonly TaskCompletionSource<string> taskCompletionSource;
        public TaskStringVisitor()
        {
            taskCompletionSource = new TaskCompletionSource<string>();
        }
        protected override void Visit(string value)
        {
            taskCompletionSource.SetResult(value);
        }
        public Task<string> Task
        {
            get { return taskCompletionSource.Task; }
        }
    }
    public static class CEFExtensions
    {
        public static Task<string> GetSourceAsync(this CefBrowser browser)
        {
            TaskStringVisitor taskStringVisitor = new TaskStringVisitor();
            browser.GetMainFrame().GetSource(taskStringVisitor);
            return taskStringVisitor.Task;
        }
    }  
