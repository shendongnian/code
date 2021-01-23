    private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {      
        string URL = "";
        if (dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
        {  
            //get the URL from the cell that you double-clicked on
            URL = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
        }
        else
            return;
        //put your code to launch the URL in a browser here        
    }
