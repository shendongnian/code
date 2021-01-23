    private void GetItemsRecursive(DependencyObject lb)
    {
        var childrenCount = VisualTreeHelper.GetChildrenCount(lb);
        for (int i = 0; i < childrenCount; i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(lb, i);
            if (child is CheckBox) // specific/child control 
            {
                CheckBox targeted_element = (CheckBox)child;
                targeted_element.IsChecked = true;
                if (targeted_element.IsChecked == true)
                {
                    return;
                }
            }
            GetItemsRecursive(child);
        }
    }
