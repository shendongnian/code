    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
      string fileToOpen = null;
      bool availability= NavigationContext.QueryString.Keys.Contains("arr");
           if (availability)
           {
               fileToOpen  = NavigationContext.QueryString["arr"];
               MessageBox.Show("On Pick: " + fileToOpen);
           }
           else {
               MessageBox.Show("Data Not Available");
           }
    base.OnNavigatedTo(e);
    }
    
   
