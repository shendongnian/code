    DataSet ds = new DataSet();
    DataTable dtUserGroups = new DataTable("UserGroups");
    DataTable dtGroups = new DataTable("Groups");
    ds.Tables.Add(dtUserGroups );
    ds.Tables.Add(dtGroups);
    using(SqlCommand cmd = new SqlCommand("SELECT * FROM UserGroups;SELECT * from Groups", con))
    {
        using(SqlDataReader dr = cmd.ExecuteReader())
        {
            ds.Load(dr, LoadOption.OverwriteChanges, dtUserGroups, dtGroups);
            
            // Now you have the two tables filled and 
            // you can read from them in the usual way
        }
    }
