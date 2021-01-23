	private void buttonSaveButton_Click(object sender, EventArgs e)
	{
		bool [,] cellIsSelected = new bool[dataGridView1.Rows.Count, dataGridView1.Columns.Count];
		foreach(var selectedCell in selectedCells)
		{
		    cellIsSelected[selectedCell.RowIndex,selectedCell.ColumnIndex] = true;
		}
		
		for(int i=0; i<dataGridView1.Rows.Count; i++)
		{
			for(int j=0; j<dataGridView1.Columns.Count; j++)
			{
		        //determine if the cell at postion i,j is selected
				if(cellIsSelected[i,j])
				{
					//It is selected.
				}
			}
		}
	}
