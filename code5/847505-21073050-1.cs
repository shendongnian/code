    string fileToOpen = null;
    MessageBox.Show("Navigation received");
     bool availability= NavigationContext.QueryString.Keys.Contains("arr");
           if (availability)
           {
               string data = NavigationContext.QueryString["arr"];
               MessageBox.Show(data);
           }
           else {
               MessageBox.Show("Data Not passed from previouse page!");
           }
