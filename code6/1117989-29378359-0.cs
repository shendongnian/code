    void GetChildControls(IList<Visual> container, Visual parent)
    {
        int childCount = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < childCount; i++)
        {
            Visual visual = (Visual)VisualTreeHelper.GetChild(parent, i);              
            container.Add(visual);
            if (VisualTreeHelper.GetChildrenCount(visual) > 0)
            {
                GetChildControls(container, visual);
            }
        }
    }
