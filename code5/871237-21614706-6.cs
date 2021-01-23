    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      if (App.returnPage)
      {
         App.returnPage = false;
         NavigationContext.QueryString.TryGetValue("id", out navId);
         NavigationService.GoBack();
      }
      else if (e.NavigationMode != NavigationMode.Reset)
      {
         // normal navigation
      }
    }
