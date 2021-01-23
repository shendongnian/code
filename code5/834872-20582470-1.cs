    StringBuilder sb = new StringBuilder();
    if (dr.Read())
    {
        for (int i = 0; i < dr.FieldCount; i++)
        {
            if (sb.Length > 0) { sb.Append(";"); }
            sb.Append(dr.GetString(i));
        }
    }
