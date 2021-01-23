    public class App : Application
    {
        public static new App Current
        {
            get { return (App) Application.Current; }
        }
        public string CustomerCode { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            this.CustomerCode = e.Args[0].Replace("/", string.Empty);
            base.OnStartup(e);
        }
    }
