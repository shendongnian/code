    foreach (var user in users.Users)
    {
       DataRow newRow = table.NewRow();
       for (int j = 0; j < properties.Count(); j++)
       {
           var colName = properties[j].Name;
           newRow[colName] = user.GetType().GetProperty(colName).GetValue(user, null);
       }
       table.Rows.Add(newRow);
    }
    foreach (DataRow row in table.Rows)
    {
        Console.WriteLine(row["id"]);
    }
