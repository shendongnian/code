    ME.Source = new Uri(MediaFilePath);
    ME.Play();
    ...
    private void DeleteButton_Click(object sender, RoutedEventArgs e) 
    { 
        ME.IsEnabled = false;   // This will call the Event Handler IsEnabledChanged 
        System.IO.File.Delete(MediaFilePath); 
        // Now after the player was stopped and cleared and source set to null, it 
        // won't object to deleting the file
    }
    private void ME_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        ME.Stop();
        ME.Clear();
        ME.Source = null;
    }
