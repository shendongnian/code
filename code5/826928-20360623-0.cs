    DataRow[] rows = Table.Select("[ts_id] in (" + IdList + ")");
    if(rows.Length > 0)
    {
       DataTable subTable = rows.CopyToDataTable();
       ......
    }
