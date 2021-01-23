    private void keepdata()
    {
     string connString = "Server=localhost;Database=databaserfid;Uid=root;Pwd=12345;";
     using (MySqlConnection mcon = new MySqlConnection(connString))
     {   
        using (cmd = mcon.CreateCommand())
        {
            try
            {
                mcon.Open();
                MessageBox.Show("Connect");
            }
            catch
            {
                MessageBox.Show("Not Connect");
            }
        }
      }
    }
