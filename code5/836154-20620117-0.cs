    public partial class App : Application
    {
        private void Application_Startup_1(object sender, StartupEventArgs e)
        {
            Task.Factory.StartNew<List<int>>(() => Querier.GetItems());
        }
    }
