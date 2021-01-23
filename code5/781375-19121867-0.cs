    private void LongListSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var myObj = AccountsList.SelectedItem as MyObject;
        if(myObj == null) return;
        
        var accountNum = myObj.AccountNumber;
        NavigationService.Navigate(new Uri(string.Format("/ViewAccount.xaml?parameter={0}&action={1}", accountNum, "View"), UriKind.Relative));
        
        // set the selectedItem to null so the page can be navigated to again 
        // If the user taps the same item
        AccountsList.SelectedItem = null;
    }
