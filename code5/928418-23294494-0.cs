    public static class MyVisualTreeHelper
    {
        public static T FindVisualChild<T>(this FrameworkElement obj, string childName) where T : FrameworkElement
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                FrameworkElement child = (FrameworkElement)VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T && child.Name == childName)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child, childName);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
