    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var assemblyLoadContextAccessor = app.ApplicationServices.GetService<IAssemblyLoadContextAccessor>();
            var loadContext = assemblyLoadContextAccessor.Default;
            var loadedAssembly = loadContext.Load("NameOfYourLibrary");
        }
    }
