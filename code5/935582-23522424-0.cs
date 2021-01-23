    private void btnUserAction_Click(object sender, RoutedEventArgs e)
    {
        myBusyIndicator.IsBusy = true;
    
        // DO your stuff
    
        var submitOperation = myContext.SubmitChanges();
    
        submitOperation.Completed += (s, e) =>
            {
              // It is completed, now the user can click on the button again 
    
              myBusyIndicator.IsBusy = false;
             }
    }
