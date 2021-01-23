        protected override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            // Your initialization code
        
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(GetViewModelType);
        
            // Your initialization code
        }
        
        private Type GetViewModelType(Type pageType)
        {
            return _viewViewModelTypeResolver.GetViewModelType(pageType);
        }
