    int control = 5;
    string colPrefix = "@COL";
    var sql = new StringBuilder("sp_INSERT ").Append(colPrefix).Append(control);
    // note first item has different format due to comma
    for(int i = control - 1; i > 0; i--)
    {
        sql.Append(", ").Append(colPrefix).Append(i);
    }
    sql.Append(';');
    string s = sql.ToString();
