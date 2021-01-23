    public FrameworkElement SearchVisualTree(DependencyObject targetElement, string elementName)
            {
                FrameworkElement res = null;
                var count = VisualTreeHelper.GetChildrenCount(targetElement);
                if (count == 0)
                    return res;
    
                for (int i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(targetElement, i);
                    if ((child as FrameworkElement).Name == elementName)
                    {
                        res = child as FrameworkElement;
                        return res;
                    }
                    else
                    {
                        res = SearchVisualTree(child, elementName);
                        if (res != null)
                            return res;
                    }
                }
                return res;
            }
