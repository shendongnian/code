    private void grid_CustomUnboundColumnData(object sender, GridColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (((NewTestData)((GridControl)sender).GetRowByListIndex(e.ListSourceRowIndex)).Number1 > 10)
                    e.Value = "demo.gif";
                else
                    e.Value = null;
            }
        }
