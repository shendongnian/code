    public static class MyVisualTreeHelpers
    {
        public static IEnumerable<FrameworkElement> GetChildren(this DependencyObject dependencyObject)
        {
            var numberOfChildren = VisualTreeHelper.GetChildrenCount(dependencyObject);
            return (from index in Enumerable.Range(0, numberOfChildren)
                    select VisualTreeHelper.GetChild(dependencyObject, index)).Cast<FrameworkElement>();
        }
    }
