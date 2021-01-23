    private void Button_Click(object sender, RoutedEventArgs e)
    {
            Button button = sender as Button;
            DependencyObject child = VisualTreeHelper.GetChild(button, 0);
            Image image = child as Image;
            //Now you can access your image Properties
    }
