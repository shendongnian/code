	private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (dataGridView.Columns[e.ColumnIndex].Name == "Availability")
			e.CellStyle.ForeColor = Color.Silver;
	}
