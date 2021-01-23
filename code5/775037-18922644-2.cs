    public ScrollViewer GetScrollViewer(DependencyObject parentElement)
        {
            var count = VisualTreeHelper.GetChildrenCount(parentElement);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parentElement, i);
                if (child is ScrollViewer)
                {
                    return child as ScrollViewer;
                }
                else
                {
                    child = GetScrollViewer(child);
                    if (child != null)
                    {
                        return child as ScrollViewer;
                    }
                }
            }
            return null;
        }
