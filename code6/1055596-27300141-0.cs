    private IUnityContainer Container { get; set; }
    
    public AdministrationService()
    {
        Container = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IUnityContainer>();
    }
