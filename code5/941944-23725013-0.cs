    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        DockPanel panel = UIHelper.FindFirstChild<DockPanel>(this);
        Console.WriteLine(VisualTreeHelper.GetChildrenCount(panel)); //returns 3
    }
