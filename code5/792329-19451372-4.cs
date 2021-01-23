    void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {   
          //here i use TestCol as a name for the column i want to check
          //you replace it with the column you have from the database
          //if you didnt change it of course...
          if (e.ColumnIndex == dataGridView1.Columns["TestCol"].Index)
          {
               //and here i assign the value on the current row in the testcolumn column
               //thats the combobox column...
               dataGridView1.Rows[e.RowIndex].Cells["testcolumn"].Value = (MyEnum)((int)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
          }
    }
    
    private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
    {
          //here i assign the initial values to the each cell in the combobox column
          //this whole example could be done in other ways but in a nutshell
          //it should provide you a good kickstart to play around.
          if (e.Row.DataBoundItem != null)
          {
               e.Row.Cells["testcolumn"].Value = (MyEnum)((int)e.Row.Cells["TestCol"].Value);
          }
    }
