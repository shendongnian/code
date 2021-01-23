     public string URL(string ID)
            {
                MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=root;database=Downloader;");
                MySqlCommand cmd = new MySqlCommand("SELECT string FROM Files WHERE ID = '" + ID + "';");
                cmd.Connection = con;
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                return reader["string"].ToString();
                else 
                return "error";//you can customize here
            }
