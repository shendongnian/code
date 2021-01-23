	private void PasteClipboard(DataGridView myDataGridView)
	{
		//Create COlumns in datagridView
		myDataGridView = new DataGridView();
		myDataGridView.Columns.Add("col1", "Col1");
		myDataGridView.Columns.Add("col2", "Col2");
		myDataGridView.Columns.Add("col3", "Col3");
		myDataGridView.Columns.Add("col4", "Col4");
		
		DataObject o = (DataObject)Clipboard.GetDataObject();
		if (o.GetDataPresent(DataFormats.Text))
		{
			string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
			foreach (string pastedRow in pastedRows)
			{
				string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });
				using (DataGridViewRow myDataGridViewRow = new DataGridViewRow())
				{
					myDataGridViewRow = (DataGridViewRow) myDataGridView.RowTemplate.Clone();
					for (int i = 0; i < pastedRowCells.Length; i++)
						myDataGridViewRow.Cells[i].Value = pastedRowCells[i];
					myDataGridView.Rows.Add(myDataGridViewRow);
				}
			}
		}
	}
