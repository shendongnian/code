    private static Collection<T> FindVisualChild<T>(DependencyObject current) where T : DependencyObject
    {
        if (current == null)
        {
            return null;
        }
        var children = new Collection<T>();
        FindVisualChild (current, children);
        return children;
    }
    private static void FindVisualChild<T>(DependencyObject current, Collection<T> children) where T : DependencyObject
    {
        if (current != null)
        {
            if (current.GetType() == typeof(T))
            {   children.Add((T)current);   }
            for (int i = 0; i < System.Windows.Media.VisualTreeHelper.GetChildrenCount(current); i++)
            {
               FindVisualChild (System.Windows.Media.VisualTreeHelper.GetChild(current, i), children);
            }
        }
    }
