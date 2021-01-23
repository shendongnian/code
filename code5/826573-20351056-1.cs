      for (int i = 0; i < (DataGridView1.Rows.Count); i++)
      {
          string colTimeOut = DataGridView1.Rows[i].Cells[4].Value.ToString();    
          MessageBox.Show(colTimeOut);
          if (String.IsNullOrEmpty(colTimeOut))
          {
              OLEDB_Connection.Open();
              updateCmd.Connection = OLEDB_Connection;
              updateCmd.CommandText = "INSERT INTO TestDB (TimeOut) VALUES (@TIMEOUT)";
              updateCmd.Parameters.AddWithValue("@TIMEOUT", varTime);
              updateCmd.ExecuteNonQuery();
              OLEDB_Connection.Close();
          }
      else  
