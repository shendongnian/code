    ICollection<string> resources = GetResources();
    // If there were 3 resources, the result would be "@res0,@res1,@res2"
    // The code should prevent the case then resources.Count() == 0 or the
    // result will result in invalid SQL below.
    var resourceParams = string.Join(",",
        resources.Select((v, i) => "@res" + i));
    // This is NOT SQL Injection because the source of resourceParams is
    // controlled and NEVER contains user data. (However, a very large IN could still
    // result in degenerate or "too many parameter" queries.)
    var sql = string.Format("SELECT [Resource No_] where [Resource No_] In ({0})",
        resourceParams);
    var cmd = conn.CreateCommand();
    cmd.CommandText = sql;
    // Assign values to placeholders, using the same naming scheme.
    // Parameters prevent SQL Injection (accidental or malicious).
    int i = 0;
    foreach (var r in resources) {
       cmd.Parameters.AddWithValue("@res" + i, r);
       i++;
    }
