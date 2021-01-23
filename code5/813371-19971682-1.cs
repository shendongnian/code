          public event Action<string> DataGridCell ;
           private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
           {
            try
            {
                if (DatagridCell!=null)
                {
                    var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    DatagridCell(value);
                        
                }
                
            }
            catch { }
        } 
