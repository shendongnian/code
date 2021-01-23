    protected override void OnNavigatedTo(NavigationEventArgs e)
    {    
        base.OnNavigatedTo(e);
        if (PhoneApplicationService.Current.State.Contains["Contact"])
        {
            listOfContact = 
                PhoneApplicationService.Current.State["Contact"] as List<CustomContact>();
        }
    }
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        base.OnNavigatedFrom(e);
        PhoneApplicationService.Current.State["Contact"] = listOfContact;
    }
