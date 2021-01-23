    StringBuilder sqlBuilder = new StringBuilder();
    sqlBuilder.Append("select [aName],[aDesc] from [Table1] where ");
    foreach (string item in keywords)
    {
        sqlBuilder.AppendFormat(
            "([aName] like '%{0}%' or [aDesc] like '%{0}%') and ", item);
    }
    // That last "AND" requires a boolean statement to follow
    // 1=1 will always return true and thus will not affect
    // the result of your WHERE clause.
    sqlBuilder.Append("1 = 1 ");
    sqlBuilder.Append("UNION select [bName],[bDesc] from [Table2] where ");
    foreach (string item in keywords)
    {
        sqlBuilder.AppendFormat(
            "([bName] like '%{0}%' or [bDesc] like '%{0}%') and ", item);
    }
