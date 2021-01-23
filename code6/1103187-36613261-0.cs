    using Microsoft.Extensions.PlatformAbstractions;
    public Startup(IApplicationEnvironment appEnv)
    {
        var path01 = PlatformServices.Default.Application.ApplicationBasePath;
        var path02 = appEnv.ApplicationBasePath;
    }
