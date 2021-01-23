    bool first = true;
    foreach (string tbl in MyTables)
    {
        if (first)
            first = false;
        else
            SQLQuery.AppendLine(" UNION ");
        SQLQuery.Append("SELECT [col1], [col2], [col3] FROM ");
        SQLQuery.AppendLine(tbl);
    }
