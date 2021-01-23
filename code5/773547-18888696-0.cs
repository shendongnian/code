    public class MainBootstrapper : MefBootstrapper
    {
       protected override Microsoft.Practices.Prism.Logging.ILoggerFacade CreateLogger()
       {
           return new Log4NetLogger();
       }
        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<Shell>();
        }
        protected override void ConfigureAggregateCatalog()
        {
            var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
            AggregateCatalog.Catalogs.Add(new DirectoryCatalog(currentFolder));
            AggregateCatalog.Catalogs.Add(new DirectoryCatalog(currentFolder + Settings.Default.ElementsFolder));
        }
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(RadPaneGroup), new RadPaneGroupRegionAdapter(ConfigureDefaultRegionBehaviors()));
            mappings.RegisterMapping(typeof(Menu), new MenuRegionAdapter(ConfigureDefaultRegionBehaviors()));
            return mappings;
        }
        protected override void InitializeShell()
        {
            var shellWindow = (Shell) Shell;
            Application.Current.MainWindow = shellWindow;
            shellWindow.Show();
            shellWindow.InjectInitialViews();
        }
        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            ViewModelInjectionBehavior.RegionsToAttachTo.Add(RegionNames.ElementViewRegion);
            var behaviorFactory = base.ConfigureDefaultRegionBehaviors();
            behaviorFactory.AddIfMissing("AutoPopulateExportedViewsBehavior", typeof(AutoPopulateExportedViewsBehavior));
            behaviorFactory.AddIfMissing("AutoPopulateExportedMenuItemsBehavior", typeof(AutoPopulateExportedMenuItemsBehavior));
            behaviorFactory.AddIfMissing("ElementViewInjectionBehavior", typeof(ViewModelInjectionBehavior));
            return behaviorFactory;
        }
    }
