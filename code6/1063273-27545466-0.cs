    private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
    {
          int id = Convert.ToInt32
          if  (dataGridView1.Rows[dataGridView1.CurrentRow].Cells["id"].Value) != null)
          {
          try
           {
              MySqlConnection conn = new MySqlConnection(connection);
              MySqlCommand command = start.CreateCommand();
              command.CommandText = "SELECT id, muayine_adi, sabit_qiymet FROM tibbi_xidmetler  WHERE                   
              id = '" + id.ToString() + "'";
              conn.Open();
              MySqlDataAdapter oxu = new MySqlDataAdapter(command);
              DataTable dt = new DataTable();
              oxu.Fill(dt);
              if (dt!=null && dt.Rows.count >0)
                {
                     int idx = dataGridView2.Rows.Count;
                     dataGridView2.Rows.Add(dt.Rows.count);
                     for (int i=0; i<=dt.Rows.Count-1; i++)
                      {
                         int rVal = (idx+i)+1;
                         dataGridView2.Rows[rVal].Cells["id"].Value = dt.Rows[i]["id"];
                         dataGridView2.Rows[rVal].Cells["nyayine_adi"].Value = dt.Rows[i]  
                         ["muayine_adi"];
                         dataGridView2.Rows[rVal].Cells["sabit_qiymet"].Value = dt.Rows[i] 
                         ["sabit_qiymet"];
                         }
                  }
              }
    catch (Exception ex)
     {
            MessageBox.Show(ex.Message);
      }
     }
    }
