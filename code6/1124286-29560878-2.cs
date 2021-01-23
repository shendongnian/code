     protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {  
            if (keyData == Keys.Down)
            {
                if(this.dataGridView1.Rows.Count > 0)
                {
                    if (dataGridView1.CurrentRow.Index == (dataGridView1.Rows.Count - 1))
                    {
                        dataGridView1.Rows.Add();
                    }
                }
                else
                {
                    dataGridView1.Rows.Add();
                }
                
                //selecting rows below current row
                if(dataGridView1.Rows.Count > 1)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Cells[dataGridView1.CurrentCell.ColumnIndex];
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
