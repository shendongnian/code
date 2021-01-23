    ITermusRepository repo { get; set;}
    public GetPDF()
    {
        var kernel = TERMUS.App_Start.NinjectWebCommon.CreateKernel();
        repo = kernel.Get<ITermusRepository>();
    }
