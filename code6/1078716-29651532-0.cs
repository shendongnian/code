    public class ...
    {
        ...
        HashSet<GridEXRow> expandedRows = new HashSet<GridEXRow>();
        public bool IsExpanded
        {
            get { return expandedRows.Count > 0; }
        }
        ...
        private void gridEX_RowCollapsed(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            expandedRows.Remove(e.Row);
        }
        private void gridEXLocation_RowExpanded(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            expandedRows.Add(e.Row);
        }
    }
