    public partial class App : Application
    {
        public string MyString { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MyString = "I'm a string in the App class";
        }
    }
