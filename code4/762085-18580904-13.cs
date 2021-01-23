    public static T GetFirstAncestorOfType<T>(DependencyObject source) where T : class
    {
        while (source != null && !(source is T))
            source = VisualTreeHelper.GetParent(source);
        return source as T;
    }
    public static MessageBoxResult DoYouAgreeToMoveToAnotherItem()
    {
        return MessageBox.Show("Select a different item?", "Select?", MessageBoxButton.YesNo);
    }
