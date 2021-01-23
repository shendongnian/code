    for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                for (int o = 0; o < dataGridView4.Rows[i].Cells.Count;o++ )
                {
                    if(Convert.ToInt32(dataGridView4.Rows[i].Cells[o].Value) < 35)
                    {
                        dataGridView4.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red; 
                    }
                }
            }
