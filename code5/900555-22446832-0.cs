    private void populate_cb(){
        cb.Items.Clear();
        SqlDataReader rdr1 = null;
        SqlConnection con1 = null;
        SqlCommand cmd1 = null;
        try
        {
            // Open connection to the database
            string ConnectionString = @"Data Source=MyPC-PC\SQLEXPRESS;Initial Catalog=DryDB;Integrated Security=True";
            con1 = new SqlConnection(ConnectionString);
            con1.Open();
            cmd1 = new SqlCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT PName from MASTER order by PName";
            cmd1.Connection = con1;
            rdr1 = cmd1.ExecuteReader();
            cb.Items.Add("Select");
            while(rdr1.Read())
            {
                cb.Items.Add(rdr1[0].ToString());
            }
            cb.SelectedIndex =0;
            con1.Close();
        }
        catch(Exception ex){
            // handle exception
        }
    }//end of populate_cb()
    
