    `foreach(DataRow dr in dt.Rows)
        {
        foreach(DataColumn dc in dt.Columns)
        {
        string s = Convert.ToString(dr[dc.ColumnName]);
        s = s.Replace("Your Search Text","<span style='color:RED'>Your Search Text</span>");
        dr[dc.ColumnName] = s;
        }
        }`
