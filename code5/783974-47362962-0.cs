    myButton.MouseRightButtonUp += MenuItemButton_Click;
    myButton.Click += MenuItemButton_Click;
    
    internal void MenuItemButton_Click(object sender, EventArgs e)
    {
        var clickedButton = sender as Button;
        string EventArgsType = e.GetType().ToString();
        //Remove leading qualification from Type ("System.Windows." or "System.Windows.Input.")
        EventArgsType = type.Substring(EventArgsType.LastIndexOf('.') + 1);
        switch (EventArgsType)
        {
            //Handle R-Click (RightMouseButtonUp)
            case "MouseButtonEventArgs":
                var MbeArgs = e as MouseButtonEventArgs;
               //Do stuff
                break;
            //Handle L-Click (Click)
            case "RoutedEventArgs":
                var ReArgs = e as RoutedEventArgs;
                //Do stuff
                break;
            default:
                break;
        }
    }
