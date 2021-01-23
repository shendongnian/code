    private void button3_Click(object sender, RoutedEventArgs e)
    {
        button3.Content = "Printing...";
        button3.IsEnabled = false;
    
        Dispatcher.Invoke((Action)(() => { }), DispatcherPriority.Render); <-- HERE
        // button3.Refresh(); <-- After having extension method on UIElement.
        Thread.Sleep(1000);
    
        button3.IsEnabled = true;
        button3.Content = "Print";
    }
