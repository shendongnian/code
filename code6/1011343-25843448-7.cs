    using (var cmd = new SqlCommand("InsertItems", connection))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        var itemsParam = new SqlParameter("@Items", SqlDbType.Structured);
        itemsParam .Value = dt;
 
        cmd.Parameters.Add(itemsParam);
        cmd.ExecuteNonQuery();
    }
