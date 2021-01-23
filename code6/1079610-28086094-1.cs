    private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 1 && e.RowIndex == 1)
		{
			DataGridViewTextBoxCell TextBoxCell = new DataGridViewTextBoxCell();
			this.dataGridView1[1, 1] = TextBoxCell;
		}
	}
