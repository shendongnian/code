    private void btnenroll_Click(object sender, RoutedEventArgs e)
    {
       string things;
       string morethings;
       try
       {
         int id;
         if(!Int32.TryParse(txtempty.Text, out id)
         {
              MessageBox.Show("Not a valid ID");
              return;
         }
         int jumla;
         if(!Int32.TryParse(txtjumla.Text, out jumla)
         {
              MessageBox.Show("Not a valid JUMLA");
              return;
         }
         int mkop;
         if(!Int32.TryParse(txtloan.Text, out mkop)
         {
              MessageBox.Show("Not a valid MKOP");
              return;
         }
         ....
         .... and so on for the other integer required by the second query
         ....
    
         id = result + 1;
         con.Open();
    
         things = "INSERT INTO vikoba.members(id_no , names_) VALUES (@id ,@name)";
         cmd = new MySqlCommand(things, con);
         cmd.Parameters.AddWithValue("@id", id);
         cmd.Parameters.AddWithValue("@name", txtname.Text);
         cmd.ExecuteNonQuery();
    
         morethings = "INSERT INTO vikoba.mpoko(id_no , jumpla_mpoko , mkopo , riba , bima) " + 
                      "VALUES  (@id, @jumla, @mkop, @riba, @bima) ";
         cmd = new MySqlCommand(morethings, con);
         cmd.Parameters.AddWithValue("@id", id);
         cmd.Parameters.AddWithValue("@jumla", jumla);
         cmd.Parameters.AddWithValue("@mkop", mkop);
         .... other parameters ...
         cmd.ExecuteNonQuery();
         con.Close();   
       }
       catch (Exception ex)
       {
          MessageBox.Show(ex.Message.ToString());
       }
    }
