    IEnumerable<DependencyObject> GetAllVisualChildren(DependencyObject o)
    {
        yield return o;
        int childCount = VisualTreeHelper.GetChildrenCount(o);
        for (int i = 0; i < childCount; i++)
        {
            foreach (DependencyObject child in
                GetAllVisualChildren(VisualTreeHelper.GetChild(i)))
            {
                yield return child;
            }
        }
    }
