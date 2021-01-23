		// add two column
		lv.Columns.Add("A");
		lv.Columns.Add("B");
		// add one item to column A and B
		var lvi = lv.Items.Add("Item 1");
		lvi.SubItems.Add("SubItem 1");
		// add once again one row to column A and B
		lvi = lv.Items.Add("Item 2");
		lvi.SubItems.Add("SubItem 2");
