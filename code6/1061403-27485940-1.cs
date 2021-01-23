     try
     {
                      dt = new DataTable();
  
                      using (MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=test;password=1234"))
                      {
                          
                          conn.Open();
                          using (MySqlCommand cmd = new MySqlCommand())
                          {
                              cmd.Connection = conn;
                              
                              string tabvalue = grid.Rows[grid.CurrentRow.Index].Cells[0].Value.ToString();
                              
                              cmd.CommandText = ("DELETE FROM `Table`.`currenttable` WHERE `ID` ='" +      tabvalue + "';");
                              MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                              da.Fill(dt);
                          }
                          conn.Close();
                      }
                  }
    catch (Exception ex)
        {
           MessageBox.Show(ex.Message);
        }
