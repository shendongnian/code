    public static DataTemplate FindTemplateForType(Type dataType, DependencyObject container)
    {
        var frameworkElement = container as FrameworkElement;
        if (frameworkElement != null)
        {
            DataTemplateKey key = new DataTemplateKey(dataType);
            var template = frameworkElement.FindResource(key) as DataTemplate;
            if (template != null)
                return template;
        }
        if (!(container is Visual || container is Visual3D))
        {
            container = FindClosestVisualParent(container);
            return FindTemplateForType(dataType, container);
        }
        else
        {
            var parent = VisualTreeHelper.GetParent(container);
            if (parent != null)
                return FindTemplateForType(dataType, parent);
            else
                return FindTemplateForType(dataType, Application.Current.Windows[0]);
        }
    }
    public static DependencyObject FindClosestVisualParent(DependencyObject initial)
    {
        DependencyObject current = initial;
        bool found = false;
        while (!found)
        {
            if (current is Visual || current is Visual3D)
            {
                found = true;
            }
            else
            {
                current = LogicalTreeHelper.GetParent(current);
            }
        }
        return current;
    }
