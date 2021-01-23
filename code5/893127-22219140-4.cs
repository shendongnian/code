    var rowUser = analyse_table.AsEnumerable()
                          .FirstOrDefault(row => user == row.Field<string>("User"));
    var rowModul = analyse_table.AsEnumerable()
                    .FirstOrDefault(Row => modul == Row.Field<string>("Modul"));
    if (rowUser == null || rowModul == null)
    {
       // Not exist so I add a new row 
    }
    if (rowUser != null && rowModul != null)
    {
         string statusUser = rowUser["Status"].ToString();
         string statusModul = rowModul["Status"].ToString();
         
    }
