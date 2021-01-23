     gridView_gruphaber.RowLoaded += new EventHandler<RowLoadedEventArgs>(gridView_News_RowLoaded);
    void gridView_News_RowLoaded(object sender, RowLoadedEventArgs e)
        {
            GridViewRow row = e.Row as GridViewRow;
            if (row != null)
            {
                row.PreviewDrop += new DragEventHandler(row_PreviewDrop); 
            }
        }
        private int droppedRowIndex = -1;
        void row_PreviewDrop(object sender, DragEventArgs e)
        {
            GridViewRow row = sender as GridViewRow;
            if (row != null)
            {
                CommonHaber droppedCommonHaber = row.Item as CommonHaber;
                droppedRowIndex = gridView_gruphaber.Items.IndexOf(droppedCommonHaber);
            }
        }
