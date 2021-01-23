    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Print("Calling async method");
            RunSomethingAsync();
        }
    
        private async void RunSomethingAsync()
        {
            Print("Before");
            string msg = await GetSlowString();
            Print("After " + msg);
            cLabel.Content = msg;
        }
    
        void Print(string message, [CallerMemberName] string method = "")
        {
            Debug.Print("{0:N2} {1} {2} {3}", DateTime.Now.Second, AppDomain.GetCurrentThreadId(), method, message);
        }
    
        private async Task<string> GetSlowString()
        {
            Print("Before");
    
            string otherResult = await OtherTask();
    
            return "GetSlow" + otherResult + await GetVerySlow(); ;
        }
    
        private Task<string> OtherTask()
        {
            return Task.Run(() =>
            {
                Print("Sleeping for 2s");
                Thread.Sleep(2 * 1000);
                Print("Sleeping done");
                return "OtherTaskResult";
            });
        }
    
        private Task<string> GetVerySlow()
        {
            Print("Inside");
            return Task.Run(() =>
            {
                Print("Sleeping 3s");
                Thread.Sleep(3000);
                Print("Sleeping Done");
                return "GetVerySlowReturn";
            });
        }
    }
