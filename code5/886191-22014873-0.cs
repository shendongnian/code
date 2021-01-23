    //dt1 contains Diffusion etc as rows
    //dt2 contains diffusion etc as columns
    //dt3 is the required table
    DataTable dt3 = new DataTable();
    DataRow dr = null;
    for (int i = 0; i < dt1.Rows.Count; i++)
    {
        if (dt2.Columns.Contains(dt1.Rows[i]["Par Name"].ToString()))
        {
            string col = dt1.Rows[i]["Par Name"].ToString();
            if (!dt3.Columns.Contains(col))
            {
                dt3.Columns.Add(col, typeof(string));
            }
            if (dt3.Rows.Count == 0)
            {
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    dr = dt3.NewRow();
                    dt3.Rows.Add(dr);
                }
            }
            for (int j = 0; j < dt2.Rows.Count; j++)
            {
                dt3.Rows[j][col] = dt2.Rows[j][col].ToString();
            }
        }
    }
