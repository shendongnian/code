    public DataTable selectCombo()
    {
           DataTable dt = new DataTable();
           string query = "SELECT DISTINCT month FROM printer_count";
            if (this.OpenConnection() == true)
            {
    
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
    
           this.CloseConnection();
           return dt;
     }
