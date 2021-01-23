        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (NavigationContext.QueryString.ContainsKey("parameter"))
            {
                  string val = NavigationContext.QueryString["parameter"];
                  switch(val)
                  {
                      case "Red":
                           this.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
                           break;
                      case "Blue":
                           this.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
                           break;
                      case "Green":
                           this.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
                           break;
                      default:
                           this.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
                           break;
                  }
            }
        }
