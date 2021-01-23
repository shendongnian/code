    string[] storeIds = { "1Store", "2Store", "RedStore", "BlueStore" };
    StringBuilder sb = new StringBuilder();
    sb.Append("select * from myTable");
    sb.Append(" where myTable.storeid in (");
    using (SqlCommand cmd = new SqlCommand())
    {
        foreach (var para in storeIds.Select((store, index)
            => new {
                index,  
                name = String.Format("@p{0}", index), 
                value = store 
            }))
        {
            if (para.index > 0) { sb.Append(","); }
            sb.Append(para.name);
            cmd.Parameters.AddWithValue(para.name, para.value);
        }
        sb.Append(")");
        cmd.CommandText = sb.ToString();
        cmd.Connection = conn;
        // Now do whatever you want with the command ...
