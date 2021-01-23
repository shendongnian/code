    Current.MainWindow is ideal in every case because if a usercontrol is embedded inside another usercontrol, you can still use Current.MainWindow traversing up the tree. All the methods are fine and it all depends on usage and what you're trying to accomplish.
    
    
    To access a control (lets say **TextBlock**) inside a user control. 
    
    TextBlock tb = FindVisualChildren<TextBlock>(usercontrol)
    
    public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj != null)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
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
