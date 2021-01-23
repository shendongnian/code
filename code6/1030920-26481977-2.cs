        for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    for (int o = 0; o < dataGridView4.Rows[i].Cells.Count;o++ )
                    {  
    	                 int num1;
                         if(dataGridView4.Rows[i].Cells[o].Value != null)
                         {
                           string text1 = dataGridView4.Rows[i].Cells[o].Value.toString;
    	                   bool res = int.TryParse(text1, out num1);
                           if (res == true)
    	                    {
    	                      if(Convert.ToInt32(dataGridView4.Rows[i].Cells[o].Value) < 35)
                             {
                              dataGridView4.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red; 
                             }
                            }
                          }
                        
                    }
                }
