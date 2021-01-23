    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {          
         if (e.ColumnIndex == dataGridView1.Columns["Your Column Name"].Index) //To check that we are in the right column
         {
              //dataGridView1.EndEdit();  //Stop editing of cell.
              if ((bool)dataGridView1.Rows[e.RowIndex].Cells["Your Column Name"].Value)
              {
                 dataGridView1.Columns[3].ReadOnly = true;
              }
        }
    }
