    using(var cn = new SqlConnection(connectionString))
    using(var cmd = new SqlCommand(query, cn))
    {
        if (txtid.Text != "" & txtname.Text != "")
        {
           cmd.CommandText = "insert into info (id,name) values (@id, @name)";
           cmd.Parameters.AddWithValue("@id", txtid.Text);
           cmd.Parameters.AddWithValue("@name", txtname.Text);
           cn.Open();
           cmd.ExecuteNonQuery(); 
           cn.Close();
           ...
        }
    }  
