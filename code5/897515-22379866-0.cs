        try
        {
            using (con = new SqlConnection(ConnectionString)) 
            {
                cmd = new SqlCommand("select * from <table-name> ", con);
                ds = new DataSet();
                var data = new SqlDataAdapter(cmd);
                data.Fill(ds);
            }
        }
        catch (Exception ex)
        {
            //Error Logic
        }
        return ds;
    }
