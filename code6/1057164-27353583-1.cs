    public static class Extensions
        {
            private static object Data;
     
         
            public static void Navigate(this NavigationService navigationService, Uri source, object data)
            {
                Data = data;
                navigationService.Navigate(source);
            }
      
            public static object GetNavigationData(this NavigationService service)
            {
                return Data;
            }
        }
