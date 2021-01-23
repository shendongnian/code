    private static ScrollBar GetScrollbar(DependencyObject dep, string name)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dep); i++)
            {
                var child = VisualTreeHelper.GetChild(dep, i);
                var bar = child as ScrollBar;
                if (bar != null && bar.Name == name)
                    return bar;
                else
                {
                    ScrollBar scrollBar = GetScrollbar(child, name);
                    if (scrollBar != null)
                        return scrollBar;
                }
            }
            return null;
        } 
