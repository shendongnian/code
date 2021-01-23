    private void MyGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
    	var dr = MyGrid.Rows[e.RowIndex];
    	var intVal = int.Parse(dr.Cells["Column1"].Value.ToString());
    	switch (intVal)
    	{
    		case 1:
    			e.CellStyle.BackColor = Color.Red;
    			break;
    		case 3:
    			e.CellStyle.BackColor = Color.Blue;
    			break;
    		case 5:
    			e.CellStyle.BackColor = Color.Green;
    			break;
    		default:
    			break;
    	}
    }
