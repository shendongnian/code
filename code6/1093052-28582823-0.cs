	private void dataGridRecord_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		var rows = dataGridRecord.Rows;
		var emptyCells = rows[e.RowIndex].Cells.Cast<DataGridViewCell>()
			.Count(cell => cell.Value == null || String.IsNullOrWhiteSpace(cell.Value.ToString()));
	
		// if there are no partial records
		if (emptyCells == 0)
		{
			for (var i = 0; i < rows.Count; i++)
			{
				rows[i].DefaultCellStyle.BackColor = Color.White;
				rows[i].ReadOnly = false;
			}
			
			FileManager.SaveDataTableToCsvFile(dataGridRecord, _fileName);
		}
		// if there are partial records
		else
		{
			if (e.ColumnIndex != 0)
			{
				for (var i = 0; i < rows.Count; i++)
				{
					// highlight current row and disable other rows
					if (rows[i] == rows[e.RowIndex])
					{
						rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
						rows[i].ReadOnly = false;
					}
					else if (rows[i] != rows[e.RowIndex])
					{
						rows[i].DefaultCellStyle.BackColor = Color.LightGray;
						rows[i].ReadOnly = true;
					}
				}
			}
			else
			{
				FileManager.SaveDataTableToCsvFile(dataGridRecord, _fileName);
			}
		}
	}
