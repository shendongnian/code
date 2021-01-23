    public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj,
                                             string name) where T : DependencyObject
    {
        if (depObj != null)
        {
           for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
           {
              DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
              if (child != null && child is T &&
                    (child as FrameworkElement).Name.Equals(name))
              {
                 yield return (T)child;
              }
              foreach (T childOfChild in FindVisualChildren<T>(child, name))
              {
                 yield return childOfChild;
              }
           }
        }
    }
