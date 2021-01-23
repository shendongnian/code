    public static class VisualHelper
    {
        public static T GetVisualChild<T>(this Visual parent) where T : Visual
        {
            T child = default(T);
            for (int index = 0; index < VisualTreeHelper.GetChildrenCount(parent); index++)
            {
                Visual visualChild = (Visual)VisualTreeHelper.GetChild(parent, index);
                child = visualChild as T;
                if (child == null)
                    child = GetVisualChild<T>(visualChild);//Find Recursively
                if (child != null)
                    break;
            }
            return child;
        }
    }
