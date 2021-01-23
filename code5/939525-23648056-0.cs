    private void Button_Click(object sender, RoutedEventArgs e)
    {
            Button button = sender as Button;
            //This to find the number of child controls inside any control 
            int childNumber = VisualTreeHelper.GetChildrenCount(button);
            //am assigning 0 since you have only one control button  
            DependencyObject child = VisualTreeHelper.GetChild(button, 0);
            FrameworkElement fe = child as FrameworkElement;
    }
