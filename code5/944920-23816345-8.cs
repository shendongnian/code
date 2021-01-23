    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Resources.Add("myParamObject", new CParametres ("Param1", "Param2"));
        }
    }
