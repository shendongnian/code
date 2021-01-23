       get { return navHomeViewCommand; }
    }
    private void NavHomeView(object ID)
    {
       int val = Convert.ToInt32(ID);
       var parameters = new NavigationParameters();
       parameters.Add("To", val);
       _regionManager.RequestNavigate("MainRegion", new Uri("HomeView", UriKind.Relative), parameters);
    }
