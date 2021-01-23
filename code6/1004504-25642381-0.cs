    if(Columnnames.Count == 0) throw new ArgumentException(
        "You need to specify at least one column");
    var sql = new StringBuilder("select ");
    bool first = true;
    foreach(var name in Columnnames) {
        if(!IsKnownColumnName(name)) { // <=== very important test
            throw new ArgumentException("Invalid column name: " + name);
        }
        sql.Append(first ? "[" : ",[").Append(name).Append("]");
        first = false;
    }
    sql.Append(" from test");
    ...
    cmd.CommandText = sql.ToString();
