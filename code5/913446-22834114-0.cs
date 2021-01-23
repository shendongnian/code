	private void PasteClipboard(DataGridView myDataGridView)
	{
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
