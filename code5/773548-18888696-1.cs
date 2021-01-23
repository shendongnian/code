    public class MainBootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<Shell>();
        }
        protected override void ConfigureAggregateCatalog()
        {
            var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
            AggregateCatalog.Catalogs.Add(new DirectoryCatalog(currentFolder));            
        }        
        protected override void InitializeShell()
        {
            var shellWindow = (Shell) Shell;
            Application.Current.MainWindow = shellWindow;
            shellWindow.Show();
            shellWindow.InjectInitialViews();
        }        
    }
