    [assembly: System.Web.PreApplicationStartMethod(typeof(ModuleInitializer), "Init")]
    public static class ModuleInitializer
    {
        public static void Init()
        {
            DynamicModuleUtility.RegisterModule(
                typeof(WebFormsDependencyInjectionHttpModule));
        }
    }
