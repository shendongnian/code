            dt.Clear();
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\HEAT_STORE\HEAT_STORE\bin\Debug\db.accdb");
            
            if(dataGridView1.Rows.Count> 0)
            {   //                                                                                                        //values                                                                                                         
                string sql = "insert into SLAB(DATE,SHIFT,HEAT_NO,THICK,WIDTH,LENGTH,PCS,ST_GRADE,LOCATION,OPTION,SLAB_NO)values(@DATE,@SHIFT,@HEAT_NO,@THICK,@WIDTH,@LENGTH,@PCS ,@ST_GRADE,@LOCATION,@OPTION,@SLAB_NO) ";//
                OleDbCommand cmd = new OleDbCommand(sql, con);
               
                for (int i = 0; i < dataGridView1.Rows.Count -1; i++)
              {
                  cmd.Parameters.AddWithValue("@DATE", dataGridView1.Rows[i].Cells[0].Value.ToString());
                  cmd.Parameters.AddWithValue("@SHIFT", dataGridView1.Rows[i].Cells[1].Value.ToString());
                  cmd.Parameters.AddWithValue("@HEAT_NO", dataGridView1.Rows[i].Cells[2].Value.ToString());
                  cmd.Parameters.AddWithValue("@THICK", dataGridView1.Rows[i].Cells[3].Value.ToString());
                  cmd.Parameters.AddWithValue("@WIDTH", dataGridView1.Rows[i].Cells[4].Value.ToString());
                  cmd.Parameters.AddWithValue("@LENGTH", dataGridView1.Rows[i].Cells[5].Value.ToString());
                  cmd.Parameters.AddWithValue("@PCS ", dataGridView1.Rows[i].Cells[6].Value.ToString());
                  cmd.Parameters.AddWithValue("@ST_GRADE", dataGridView1.Rows[i].Cells[7].Value.ToString());
                  cmd.Parameters.AddWithValue("@LOCATION", dataGridView1.Rows[i].Cells[8].Value.ToString());
                  cmd.Parameters.AddWithValue("@OPTION", dataGridView1.Rows[i].Cells[9].Value.ToString());
                  cmd.Parameters.AddWithValue("@SLAB_NO", dataGridView1.Rows[i].Cells[10].Value.ToString());
               
               
                }
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;  
                MessageBox.Show("SaccessFuly");
               
            }
        }
