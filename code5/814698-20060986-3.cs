    public void Navigate(Type target, Extras extras)
    {
        Type pageType;
        if (navigationTargets.TryGetValue(target, out pageType))
        {
            var uri = CreateUri(pageType, extras);
            navigationService.NavigateTo(uri);
        }
        
        // error handling here
    }
