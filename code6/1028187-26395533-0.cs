    public static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
            {
                if (parent != null)
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                    {
                        var child = VisualTreeHelper.GetChild(parent, i);
    
                        // If the available child is not null and is of required Type<T> then return with this child else continue this loop
                        if (child != null && child is T)
                        {
                            yield return (T)child;
                        }
    
                        foreach (T childOfChild in FindVisualChildren<T>(child))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
