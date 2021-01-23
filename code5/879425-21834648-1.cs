    public NancyBootstrapper(IUnityContainer container) {
        if(container == null)
            throw new ArgumentNullException("container");
        this._unityContainer = container;
    }
    protected override IUnityContainer GetApplicationContainer() {
        return _unityContainer;
    }
