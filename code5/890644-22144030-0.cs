        private void dateData_Loaded(object sender, RoutedEventArgs e)
        {
          if(NavigationContext.QueryString.ContainsKey("Date"))
           {
            dateData.Value = DateTime.Parse(NavigationContext.QueryString["Date"]);
            NavigationContext.QueryString.Remove("Date");
           }
        }
