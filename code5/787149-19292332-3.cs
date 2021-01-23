    // this loop also orders entries by database name and date
    foreach (var item in map.OrderBy(m => m.Key.DbName).ThenBy(m => m.Key.Date))
    {
        Console.WriteLine("Journal: {0} - {1:dd/MM/yyyy}", 
            item.Key.DbName, 
            item.Key.Date);
        foreach (var entry in item.Value.OrderBy(e => e.LineNumber))
        {
            Console.WriteLine(" - Line {0}, Amount = {1:0.00}",
                entry.LineNumber,
                entry.Amount);
        }
    }
