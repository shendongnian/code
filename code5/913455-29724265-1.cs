	DataObject o = (DataObject)Clipboard.GetDataObject();
	if (o.GetDataPresent(DataFormats.Text))
	{
		if (myDataGridView.Rows.Count > 0)
			myDataGridView.Rows.Clear();
		if (myDataGridView.Columns.Count > 0)
			myDataGridView.Columns.Clear();
		bool columnsAdded = false;
		string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
		foreach (string pastedRow in pastedRows)
		{
			string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });
			if (!columnsAdded)
			{
				for (int i = 0; i < pastedRowCells.Length; i++)
					myDataGridView.Columns.Add("col" + i, pastedRowCells[i]);
				columnsAdded = true;
				continue;
			}
			myDataGridView.Rows.Add(pastedRowCells);
			//***You don't need following lines, use just above line. ***
			//myDataGridView.Rows.Add();
			//int myRowIndex = myDataGridView.Rows.Count - 1;
			//using (DataGridViewRow myDataGridViewRow = myDataGridView.Rows[myRowIndex])
			//{
			//    for (int i = 0; i < pastedRowCells.Length; i++)
			//        myDataGridViewRow.Cells[i].Value = pastedRowCells[i];
			//}
		}
	}
