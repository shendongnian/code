	private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
	{
		int i;
		if (!int.TryParse(e.FormattedValue.ToString(), out i))
		{
			e.Cancel = true;
			MessageBox.Show("Please input a integral number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
