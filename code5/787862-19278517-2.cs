    StringBuilder sqlBuilder = new StringBuilder();
    sqlBuilder.Append("select [aName],[aDesc] from [Table1] where");
    foreach (string item in keywords)
    {
        sqlBuilder1.AppendFormat(
            "([aName] like '%{0}%' or [aDesc] like '%{0}%') and ", item);
    }
    // make sure to cap that last "and" statement with 
    // "1 = 1" or by stripping the last 4 chars, etc.
    sqlBuilder.Append("UNION select [bName],[bDesc] from [Table2] where");
    foreach (string item in keywords)
    {
        sqlBuilder.AppendFormat(
            "([bName] like '%{0}%' or [bDesc] like '%{0}%') and ", item);
    }
