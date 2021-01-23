    var kernel = new StandardKernel();
    kernel.Bind<IUrl>().ToMethod(ctx =>
    {
        IRequest controllerRequest = ctx.Request.TraverseRequestChainAndFindMatch(x => x.Target.Name.EndsWith("Controller"));
        if (controllerRequest != null)
        {
            return new ControllerBasedUrl(controllerRequest.Target.Type.Name);
        }
        return new AppConfigBasedUrl();
    });
