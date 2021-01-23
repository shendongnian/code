    if (e.Key == Key.Enter)
    {
        var txt = sender as TextBox;
        var selecteditem = FindParent<ContentPresenter>(txt);
        int index = myItemsCtl.ItemContainerGenerator.IndexFromContainer(selecteditem);
        if (index < myItemsCtl.Items.Count)
        {
            var afterItem = myItemsCtl.ItemContainerGenerator.ContainerFromIndex(index + 1) as Visual;
            TextBox tbFind = GetDescendantByType(afterItem, typeof(TextBox), "txtBoxName") as TextBox;
            if (tbFind != null)
            {
                FocusHelper.Focus(tbFind);
            }
        }
    }
