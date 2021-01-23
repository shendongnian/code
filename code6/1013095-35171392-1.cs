    public void AutoUpdateColumnWidth(ListView lv)
    {
    	ListViewItem nLstItem = new ListViewItem(lv.Columns(0).Text);
    	for (int i = 1; i <= lv.Columns.Count - 1; i++) {
    		nLstItem.SubItems.Add(lv.Columns(i).Text);
    	}
    	v.Items.Add(nLstItem);
    	lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
    	lv.Items.RemoveAt(nLstItem.Index);
    }
