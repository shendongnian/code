    if (lstLogMessages.SelectedIndices.Count > 0)
    {
        Rectangle selectedItemArea = lstLogMessages.Items[lstLogMessages.SelectedIndices[0]].Bounds;
        Rectangle listviewClientArea = lstLogMessages.ClientRectangle;
        int headerHeight = lstLogMessages.TopItem.Bounds.Top;
        if (selectedItemArea.Y + selectedItemArea.Height > headerHeight && selectedItemArea.Y < listviewClientArea.Height)   // if the selected item is in the visible region 
        {
            lstLogMessages.Items[lstLogMessages.SelectedIndices[0]].Focused = true;
        }
        else
        {
            lstLogMessages.TopItem.Focused = true;
        }
    }
    lstLogMessages.VirtualListSize = currentView.MessageCount;
