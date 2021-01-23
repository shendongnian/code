    public List<Control> Children(DependencyObject parent)
    {
        var list = new List<Control>();
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is Control)
                list.Add(child as Control);
            list.AddRange(Children(child));
        }
        return list;
    }
