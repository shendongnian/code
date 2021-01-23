    public static void PerformOperationOnVisualTreeControl<T>(Visual myVisual, Action<T> action)
    {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                var childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
                if (typeof(T) == childVisual.GetType())
                {
                    T control = (T)System.Convert.ChangeType(childVisual, typeof(T));
                    action(control);
                }
                ClearContent<T>(childVisual, action);
            }
    }
