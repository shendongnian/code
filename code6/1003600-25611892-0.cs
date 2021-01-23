    string[] Array1 = new string[3];   
                
                    for (int i = 0; i < dataGridView1.Rows.Count; i +=1)
                    {
                        Array1 [0] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        Array1 [1] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        Array1 [2] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    }
            
