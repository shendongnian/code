    [ModuleExport(typeof(ModuleA))]
    public class ModuleA : IModule
    {
        private readonly IRegionManager regionManager;
        [ImportingConstructor]
        public ModuleA(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion("Region1", typeof(MyUserControl));
        }
    }
