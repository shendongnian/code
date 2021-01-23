    public static class VisualChildExtractHelper
    {
      public static T FindChildOfType<T>(DependencyObject root) where T : class
      {
        var queue = new Queue<DependencyObject>();
        queue.Enqueue(root);
 
        while (queue.Count > 0)
        {
            DependencyObject current = queue.Dequeue();
            for (int i = VisualTreeHelper.GetChildrenCount(current) - 1; 0 <= i; i--)
            {
                var child = VisualTreeHelper.GetChild(current, i);
                var typedChild = child as T;
                if (typedChild != null)
                {
                    return typedChild;
                }
                queue.Enqueue(child);
            }
        }
        return null;
      }
    }
