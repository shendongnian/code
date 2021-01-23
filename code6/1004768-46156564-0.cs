    MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
    conn_string.Server = "127.0.0.1";
    conn_string.UserID = "sa";
    conn_string.Password = "myPassword";
    conn_string.Database = "myDatabase";
    
                
    MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
    
    
    try
    {
        MyCon.Open();
        MessageBox.Show("Open");
        MyCon.Close();
        MessageBox.Show("Close");
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
