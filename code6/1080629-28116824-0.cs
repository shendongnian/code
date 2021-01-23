    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        ScrollViewer scrollViewer = GetVisualChild<ScrollViewer>(dgFamily);
        if (scrollViewer != null)
            scrollViewer.ScrollChanged += scrollViewer_ScrollChanged;
    }
    void scrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        if (e.VerticalOffset == 0)
            MessageBox.Show("You reach to top");
    }
    private static T GetVisualChild<T>(DependencyObject parent) where T : Visual
    {
        T child = default(T);
    
        int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < numVisuals; i++)
        {
            Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
            child = v as T;
            if (child == null)
            {
                child = GetVisualChild<T>(v);
            }
            if (child != null)
            {
                break;
            }
        }
        return child;
    }
