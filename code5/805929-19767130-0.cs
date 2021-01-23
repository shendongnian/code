    private void button3_Click(object sender, RoutedEventArgs e)
    {
        button3.Content = "Printing...";
        button3.IsEnabled = false;
    
        Dispatcher.Invoke((Action)(() => { }), DispatcherPriority.Render); <-- HERE
        Thread.Sleep(1000);
    
        button3.IsEnabled = true;
        button3.Content = "Print";
    }
