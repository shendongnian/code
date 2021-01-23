    private IYourType _yourType;
    public override void Initialize(string name, NameValueCollection config)
    {
        ...
         _yourType = GlobalConfiguration
                     .Configuration
                     .DependencyResolver
                     .GetService(typeof(IYourType)) as IYourType;
