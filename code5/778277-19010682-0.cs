    public static DependencyObject GetScrollViewer(DependencyObject Object)
    {
        if (Object is ScrollViewer)
        {
            return Object;
        }
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(Object); i++)
        {
            var child = VisualTreeHelper.GetChild(Object, i);
            var result = GetScrollViewer(child);
            if (result == null)
            {
                continue;
            }
            else
            {
                return result;
            }
        }
        return null;
    }
