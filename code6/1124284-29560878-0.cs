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
                    
                    return true;
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
