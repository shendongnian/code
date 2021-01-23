    var parameters = new string[keys.Count()];
    for (int i = 0; i < keys.Count(); i++)
    {
        parameters[i] = string.Format("@Key{0}", i);
        cmd.Parameters.AddWithValue(parameters[i], items[i]);
    }
    cmd.CommandText = string.Format(updateQuery, string.Join(", ", parameters));
