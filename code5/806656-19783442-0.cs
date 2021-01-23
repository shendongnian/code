    private void Deleting(object sender, RoutedEventArgs e)
    {
        MessageBoxResult message = MessageBox.Show(
            "The file will be permanently deleted. Continue?",
            "Delete File", 
            MessageBoxButton.OKCancel
        );
    
        if (message == MessageBoxResult.OK)
        {                  
            SoundData data1 = myLongListSelector.SelectedItem as SoundData;
 
            if (data1 == null)
                return;
   
           //control goes inside this block  
        }
    }
  
