    ICollection<string> resources = GetResources();
    if (!resources.Any()) {
        // "[Resource No_] IN ()" doesn't make sense
        throw new Exception("Whoops, have to use different query!");
    }
    // If there is 1 resource, the result would be "@res0" ..
    // If there were 3 resources, the result would be "@res0,@res1,@res2" .. etc
    var resourceParams = string.Join(",",
        resources.Select((v, i) => "@res" + i));
    // This is NOT vulnerable to classic SQL Injection because resourceParams
    // does NOT contain user data; only the parameter names.
    // However, a large number of items in resources could result in degenerate
    // or "too many parameter" queries so limit guards should be used,
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
