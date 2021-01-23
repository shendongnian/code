    using Microsoft.Extensions.PlatformAbstractions;
    public Startup(IApplicationEnvironment appEnv)
    {
        // approach 1
        var path01 = PlatformServices.Default.Application.ApplicationBasePath;
        
        // approach 2
        var path02 = appEnv.ApplicationBasePath;
    }
