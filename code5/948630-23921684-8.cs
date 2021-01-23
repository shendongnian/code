    using (OleDbConnection con = new OleDbConnection(constring))
    {
       try
       {
          string cmdstring = @"UPDATE EMPLOYEE 
                               SET Location = @location, 
                               Comments = @Comments,
                               [Position] = @position 
                               WHERE TellerNum = @teller";
          using (OleDbCommand cmd = new OleDbCommand(cmdstring, con))
          {
             cmd.Parameters.AddWithValue("@location", comboBox18.Text);
             cmd.Parameters.AddWithValue("@comments", textBox8.Text);
             cmd.Parameters.AddWithValue("@position", comboBox19.Text);
             cmd.Parameters.AddWithValue("@teller", comboBox17.Text);
             con.Open();
             cmd.ExecuteNonQuery();
          }
       }
       catch (Exception ex)
       {
          MessageBox.Show("Failed due to " + ex.Message);
       }
    }
