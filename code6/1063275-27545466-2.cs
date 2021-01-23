    private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
            {
              
                    if (dataGridView1.CurrentRow.Cells["Id"].Value != null)
                    {
                        int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
    
                        MySqlConnection start = new MySqlConnection(baglanti);
                        MySqlCommand command = start.CreateCommand();
                        command.CommandText = "SELECT id, muayine_adi, sabit_qiymet FROM tibbi_xidmetler  WHERE id = '" + Id + "'";
                        start.Open();
                        MySqlDataAdapter oxu = new MySqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        oxu.Fill(dt);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int idx = dataGridView2.Rows.Count - 1;
                            dataGridView2.Rows.Add(dt.Rows.Count);
                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                int rVal = (idx + i) + 1;
                                dataGridView2.Rows[rVal].Cells["id"].Value = dt.Rows[i]["id"].ToString();
                                dataGridView2.Rows[rVal].Cells["muayine_adi"].Value = dt.Rows[i]["muayine_adi"].ToString();
                                dataGridView2.Rows[rVal].Cells["sabit_qiymet"].Value = dt.Rows[i]["sabit_qiymet"].ToString();
                            }
    
                        }
                        start.Close();
                    }
            }
