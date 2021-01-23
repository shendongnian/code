     using(MySqlConnection c = new MySqlConnection("Server=**;Database=***;Uid=**;Pwd=**;"))
       {
        
         using (MySqlCommand cmd = new MySqlCommand("DELETE FROM users WHERE username = @name"))
         {
             var userParam = new MySqlParameter();
             userParam.Name = "@name";
             userParam.Value = textbox1.Text;
             cmd.Parameters.Add(userParam);
    
             c.Open();
             var recordsAffected = cmd.ExecuteNonQuery();
             c.Close();
    
             if (recordsAffected == 1)
             {
                MessageBox.Show("Benutzer erfolgreich entfernt, Sir!");
              
             }
           }
         }
