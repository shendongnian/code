    string sql = "INSERT INTO TABLE1(col1, col2, col3, col4, col5) VALUES (,NULL, NULL, NULL, NULL, NULL,)";
    string nulls = "NULL";
    List<int> indexes = new List<int>();
    foreach (Match match in Regex.Matches(sql, nulls))
    {
         indexes.Add(match.Index);
    }
    sql = sql.Remove(indexes[2], 4).Insert(indexes[2], "'abc'");
    Console.WriteLine(sql);
