    private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {      
        if (dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
        {  
            //get the URL from the cell that you double-clicked on
            string URL = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
        }
        //put your code to launch the URL in a browser here        
    }
