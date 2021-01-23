    private void dataGrid_Scroll(object sender, ScrollEventArgs scrollEventArgs)
    {
        if (dataGrid.DisplayedRowCount(false) + 
            dataGrid.FirstDisplayedScrollingRowIndex
            >= dataGrid.RowCount)
        {
            // at bottom
        }
        else
        {
            // not at bottom
        }
    }
