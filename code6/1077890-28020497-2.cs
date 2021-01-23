    var rows = from a in dtfff.AsEnumerable()
               join b in dtff.AsEnumerable()
               on a["contacts"].ToString() equals b["contacts"].ToString()
               into g
               where g.Count() > 0
               select a;
    DataTable merged;
    if (rows.Any())
       merged = rows.CopyToDataTable();
    else
        merged = dtfff.Clone();
    return merged;
