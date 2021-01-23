     public LoginViewModel(IFrameNavigationService navigationService)
     {
          _navigationService = navigationService; 
     }
    ...
    _navigationService.NavigateTo("Notes",data);
    ..
