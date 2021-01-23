    StringBuilder sb = new StringBuilder();
    int RowIndex = 0; //set the row index here.
    for (int iCol = 0; iCol < dataGridView1.ColumnCount; iCol++)
    {
    	if (dataGridView1.Rows[RowIndex].Cells[iCol].Value != null)
    		sb.Append(dataGridView1.Columns[iCol].HeaderText + ":" + dataGridView1.Rows[RowIndex].Cells[iCol].Value.ToString() + ",");
    	else
    		sb.Append(dataGridView1.Columns[iCol].HeaderText + ":,");
    }
    string RowValues = sb.ToString();
    //To Remove the last seperator ","
    RowValues = RowValues.Substring(0, RowValues.Length - 1);
