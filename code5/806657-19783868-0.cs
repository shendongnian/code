    private void Deleting(object sender, RoutedEventArgs e)
    {
        SoundData data1 = (sender as MenuItem).DataContext as SoundData;
        
        MessageBoxResult message = MessageBox.Show(
        "The file will be permanently deleted. Continue?",
        "Delete File", 
        MessageBoxButton.OKCancel
        );
        if (message == MessageBoxResult.OK)
        {   
            //Call the method which deletes the data and pass data1 to it.
        }
    }
