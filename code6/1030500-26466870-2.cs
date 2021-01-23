    foreach (DataTable dt in ds.Tables)
    {
        if (dt.Rows.Count > 0)
        {
            foreach (DataColumn col in dt.Columns)
            {
                object first = dt.Rows[0][col];
                if (dt.AsEnumerable().Skip(1).All(r => r[col].Equals(first)))
                {
                    dt.Columns.Remove(col);
                }
            }
        }
    }
