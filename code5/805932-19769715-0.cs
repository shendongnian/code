    private async void button3_Click(object sender, RoutedEventArgs e)
    {
        button3.Content = "Printing...";
        button3.IsEnabled = false;
    
        await Task.Delay(1000);
    
        button3.IsEnabled = true;
        button3.Content = "Print";
    }
