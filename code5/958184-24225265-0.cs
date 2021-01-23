    private void button4_Click(object sender, EventArgs e)
            {
                DateTime dt = DateTime.Now;
                dataGridView1.Rows.Add("" + dt.Year.ToString() + "", "En cours", "0");
    
    
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
    
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        // int ik = (int)dataGridView1.Rows[i].Cells[3].Value;
                        foreach (DataGridViewRow row1 in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell cell in row1.Cells)
                            {
                                int counter = 0;
                                if (cell.Value != null && counter < 0)
                                {
                                    dataGridView1.Rows[i].Cells[2].Value = 1;
                                    counter++;
                                }
                                else  //if (string.IsNullOrEmpty( cell.Value.ToString()))
                                {
                                    break;
                                }   
                            }
                        }
                    }
                }
            }
        }
