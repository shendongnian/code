    public static class XAMLExtensions
    {
        public static T GetParent<T>(this DependencyObject dependencyObject) where T : DependencyObject
        {
            var parentDependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            switch (parentDependencyObject)
            {
                case null:
                    return null;
                case T parent:
                    return parent;
                default:
                    return GetParent<T>(parentDependencyObject);
            }        
        }
    }
