    // loop through every item in the list from the top, until we find one that is
    // within the listview's visible area
    private int GetListViewTopVisibleItem()
    {
        foreach (ListViewItem item In ListView1.Items)
        {
            if (ListView1.ClientRectangle.IntersectsWith(item.GetBounds(ItemBoundsPortion.Entire)))
            {
                // +2 as the above intersection doesn't take into account the height
                // of the listview's header (in Detail mode, which my listview is)
                return (item.Index + 2);
            }
        }
        // failsafe: return a valid index (which won't be used)
        return 0;
    }
    private void RemoveOldestItem()
    {
        // pause redrawing of the listview while we fiddle...
        ListView1.SuspendLayout();
        // if we are not auto-scrolling to the most recent item, and there are
        // still items in the list:
        int TopItemIndex = 0;
        if (!AllowAutoScroll && (ListView1.SelectedItems.Count > 0))
            TopItemIndex = GetListViewTopVisibleItem();
        // remove the first item in the list
        ListView1.Items.RemoveAt(0);
        // if we are not auto-scrolling, and the previous top visible item was not
        // the one we just removed, make that previously top-visible item visible
        // again.  (We decrement TopItemIndex as we just removed the first item from
        // the list, which means all indexes have shifted down by 1)
        if (!AllowAutoScroll && (--TopItemIndex > 0))
            ListView1.Items(TopItemIndex).EnsureVisible();
        
        // allow redraw of the listview now
        ListView1.ResumeLayout()
    }
