    bool isBtnClicked = false;
    
    private void MyLLS_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // check if button is clicked, if so, return and reset the isBtnClicked flag.
        if (isBtnClicked)
        {
            isBtnClicked = false;
            return;
        }
        var item = (MyItemType)MyLLS.SelectedItem;
        // Job 1 goes here
    }
    
    private void btDownload_Click(object sender, RoutedEventArgs e)
    {
        var button = (MyItemType)(sender as Button).DataContext; 
        // set it true when button clicked
        isBtnClicked = true;         
        // Job 2 goes here
    }
