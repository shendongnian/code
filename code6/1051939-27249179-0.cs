    private bool IsElementVisible(FrameworkElement element, FrameworkElement container)
        {
            if (!element.IsVisible)
                return false;
            Rect bounds = element.TransformToAncestor(container).TransformBounds(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
            Rect rect = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);
            if (rect.Left > bounds.Right || rect.Right < bounds.Left || rect.Bottom < bounds.Top || rect.Top > bounds.Bottom)
            {
                return false;
            }
            return true;
        }
