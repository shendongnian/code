    protected override Task OnInitializeAsync(IActivatedEventArgs args)
     {
         _container.RegisterInstance(NavigationService);
         ViewModelLocationProvider.SetDefaultViewModelFactory(vmType => _container.Resolve(vmType));
         ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
         {
              var viewModelTypeName = string.Format(CultureInfo.InvariantCulture, "Application.Pages.{0}ViewModel, Application, Version=1.0.0.0, Culture=neutral", viewType.Name);
              var viewModelType = Type.GetType(viewModelTypeName);
              return viewModelType;
         });
    
         return Task.FromResult<object>(null);
    }
