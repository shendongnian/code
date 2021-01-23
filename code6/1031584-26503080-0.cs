    ...
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();
    
                    string stm = "SELECT * FROM elsvo_zpravy";
                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    rdr = cmd.ExecuteReader();
                    string vypis = "";
                    while (rdr.Read())
                    {
                      
                      vypis += (rdr.GetInt32(0) + " - " + rdr.GetString(1) + " - " + rdr.GetString(2) + " - " + rdr.GetString(3) + "\n");
                      
                    }
                    vypisBlock.Text = vypis;
    
                }
    ...
