    Messenger.Default.Register<NavigateToPageMessage>(this, (action) => ReceiveMessage(action));
    
     private object ReceiveMessage(NavigateToPageMessage action)
            {
                var page = string.Format("/Views/{0}.xaml", action.PageName);           
                NavigationService.Navigate(new System.Uri(page,System.UriKind.Relative));
                return null;
            }
