    internal SitemapProvider(IActionResultFactory actionResultFactory, IBaseUrlProvider baseUrlProvider)
    {
        _actionResultFactory = actionResultFactory;
        _baseUrlProvider = baseUrlProvider;
    }
    public SitemapProvider() : this(new ActionResultFactory(), new BaseUrlProvider()) { }
