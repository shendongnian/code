    var kernel = new StandardKernel();
    if (runningInConsoleApplication)
    {
        kernel.Bind<IUrl>().To<AppConfigBasedUrl>();
    }
    else
    {
        kernel.Bind<IUrl>().ToMethod(ctx =>
        {
            IRequest controllerRequest = ctx.Request.TraverseRequestChainAndFindMatch(x => x.Target.Name.EndsWith("Controller"));
            return new ControllerBasedUrl(controllerRequest.Target.Type.Name);
        });
    }
