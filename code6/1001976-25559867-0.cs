    var properties = users.Users[0].GetType().GetProperties();
    foreach (PropertyInfo prop in properties)
    {
        table.Columns.Add(prop.Name);
        Console.WriteLine(prop.Name);
    }
