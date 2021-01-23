    public static T FindFirstElementInVisualTree<T>(DependencyObject parentElement) where T : DependencyObject
            {
                try
                {
                    int childCount = VisualTreeHelper.GetChildrenCount(parentElement);
                    if (childCount == 0)
                        return null;
    
                    for (int i = 0; i < childCount; i++)
                    {
                        var child = VisualTreeHelper.GetChild(parentElement, i);
                        if (child != null && child is T)
                        {
                            return (T)child;
                        }
                        else
                        {
                            var result = FindFirstElementInVisualTree<T>(child);
                            if (result != null)
                                return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            }
