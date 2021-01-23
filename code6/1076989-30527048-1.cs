    protected void Button7_Click(object sender,EventArgs e)
    { 
            String query = @"insert into event (Status) values (@param) where time='" + Time + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@param", ((Button)sender).Text);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(HttpUnhandledException ex){}
            conn.Close();
        }
