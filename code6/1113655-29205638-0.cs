    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
       //parameters from Toast
       if (!string.IsNullOrEmpty(e.Arguments))
       {
           string arguments= e.Arguments;
           if (arguments == "Whatever")
           {
               this.Frame.Navigate(typeof(HomeScreenV2));
           }
        }    
    }
