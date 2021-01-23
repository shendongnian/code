    private async void Process_Click(object sender, RoutedEventArgs e)
    {
        var results = await ProcessAsync();
    
        System.Windows.MessageBox.Show("Done");
    }
