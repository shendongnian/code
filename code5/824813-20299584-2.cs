     public string URL(string ID)
            {   
                String result="";
                using(MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=root;database=Downloader;"))
               {
                using(MySqlCommand cmd = new MySqlCommand("SELECT string FROM Files WHERE ID =@ID;"))
                {
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@ID",ID);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                if(reader.Read())
                result=reader["string"].ToString();
                else 
                result="";//you can customize here
                }
               }
              }
                return result;
            }
