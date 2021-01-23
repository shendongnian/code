    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
         var data =(Cast as byte array)PhoneApplicationService.Current.State["Data"]
         PhoneApplicationService.Current.State.Remove("Data");
        }
