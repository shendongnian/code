    public static FrameworkElement GetTemplateChildByName(DependencyObject parent, string name)
    {
        int childnum = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < childnum; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is FrameworkElement &&
            ((FrameworkElement)child).Name == name)
            {
                return child as FrameworkElement;
            }
            else
            {
                var s = GetTemplateChildByName(child, name);
                if (s != null)
                    return s;
            }
        }
        return null;
    }
