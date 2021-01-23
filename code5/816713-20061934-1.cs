    command.Parameters.Add("@my_last_name ", SqlDbType.NVarChar, 50).Value = someVariableThatCouldBeNull;
    // Other parameter
    // Third Parameter
    // fourth
    // etc
    foreach (var p in command.Parameters.Where(p => p.Value == null))
    { p.Value = DBNull.Value;}
    
