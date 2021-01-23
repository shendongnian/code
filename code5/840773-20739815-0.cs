    List<string> resources = GetResources();
    // If there were two resources, the output would be "@res0,@res1"
    var resourceParams = string.Join(","
        resources.Select((v, i) => "@res" + i).ToArray());
    // This is NOT SQL Injection because the source of resourceParams is
    // controlled and NEVER contains user data. (However, a very large IN could still
    // result in degenerate or result in "too many parameter" queries.)
    var sql = string.Format("SELECT [Resource No_] where [Resource No_] In ({0})",
        resourceParams);
    var cmd = conn.CreateCommand();
    cmd.CommandText = sql;
    // Assign values to placeholders, using the same naming scheme
    int i = 0;
    foreach (var r in resources) {
       cmd.Parameters.Add("@res" + i, r);
       i++;
    }
