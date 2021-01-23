       protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string x = "";
            string y = "";
            string z = "";
            
            NavigationContext.QueryString.TryGetValue("xValue", out x);
            NavigationContext.QueryString.TryGetValue("yValue", out y);
            NavigationContext.QueryString.TryGetValue("zValue", out z);
           // Then what ever you want to do with x,y and z value
        }
