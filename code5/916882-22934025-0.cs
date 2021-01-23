    try
    {
        if (IsFullyOrPartiallyVisible((ListBoxItem)listViewData.ItemContainerGenerator.ContainerFromItem(listViewData.Items[listViewData.Items.Count - 1]), listViewData))
        {
            listViewData.SelectedIndex = listViewData.Items.Count - 1;
            listViewData.ScrollIntoView(listViewData.SelectedItem);
        }
    }
    catch { }
