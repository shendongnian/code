    public static class BoundsHelper
    {
        public static Rect GetBoundsInParentContainer(Control control)
        {
            Vector offset = VisualTreeHelper.GetOffset(control);
            Rect rect = new Rect(offset.X, offset.Y, control.ActualHeight, control.ActualWidth);
            return rect;
        }
    }
