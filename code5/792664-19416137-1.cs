    IEnumerable<XElement> items = d.Descendants("level").Elements();
    string names = string.Empty;
    string values = string.Empty;
    foreach (XElement item in items)
    {
        names += item.Name + ",";
        values += "@" + item.Name + ",";
        IDbDataParameter parameter = datacommand1.CreateParameter();
        parameter.ParameterName = "@" + item.Name;
        parameter.DbType = DbType.String;
        parameter.Value = item.Value;
        datacommand1.Parameters.Add(parameter);
    }
    datacommand1.CommandText = "INSERT INTO MyTable (" + names.Substring(names.Length - 1) + ") VALUES (" + values.Substring(values.Length - 1) + ");";
    datacommand1.ExecuteNonQuery();
