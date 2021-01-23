    public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
---
    foreach (Image Images in FindVisualChildren<Image>(pageMain))
            {
                Canvas.SetLeft(Images, Canvas.GetLeft(Images) * (ratioWidth));
                Canvas.SetTop(Images, Canvas.GetTop(Images) * (ratioHeight));
                Images.Width = Images.ActualWidth * (ratioWidth);
                Images.Height = Images.ActualHeight * (ratioHeight);
            }
