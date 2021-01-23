    private void OnStartNewWindow(object sender, RoutedEventArgs args)
    {
        this.Dispatcher.Invoke((Action)(delegate()
        {
            // Create and show the Window
            Window tempWindow = new Window();
            Rectangle rect = new Rectangle();
            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(rect);
            tempWindow.Content = stackPanel;
            tempWindow.Show();
        }));
     }
