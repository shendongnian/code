    lv.Items.Clear();
    foreach (string newval in stringlist)
	    lv.Items.Add(newval);
    lv.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.None);
    lv.Columns[0].Width = 'Your own size';
    lv.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
