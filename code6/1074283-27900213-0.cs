    foreach (var h in d.ColumnHeaders)
    {
        SqlConnection sqlCon = ...
        sqlCon.Open();
        ... // snip
        sqlCon.Close();
    }
