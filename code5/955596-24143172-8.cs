    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow mw = new MainWindow(DoSomething);
            mw.Show();
        }
        public void DoSomething()
        {
        }
    }
