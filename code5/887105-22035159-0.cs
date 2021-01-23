    using(SqlConnection conn = new SqlConnection(connection))
    {    
       using(SqlCommand cmd = conn.CreateCommand())
       {
         ....
            while (rdr.Read())
            {
                string sName = rdr.GetString(0); 
                comboBox1.Items.Add(sName);
            }
       }
    }
