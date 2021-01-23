     protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string ActivityID;
            if (e.IsNavigationInitiator  && this.NavigationContext.QueryString.TryGetValue("ActivityID", out ActivityID))
            {
              ActivityID= int.Parse(ActivityID);
            }
        }
