    List<Column> Columns = new List<Column>
    {
       new Column { LocId = 1 , SecId = 1, StartElevation = 0, EndElevation = 160 },
       new Column { LocId = 1 , SecId = 1, StartElevation = 160, EndElevation = 320 },
       new Column { LocId = 1 , SecId = 2, StartElevation = 320, EndElevation = 640 },
       new Column { LocId = 2 , SecId = 1, StartElevation = 0, EndElevation = 160 },
       new Column { LocId = 2 , SecId = 2, StartElevation = 160, EndElevation = 320 }
    };
    
    foreach (var group in Columns.GroupBy(c => new { c.LocId, c.SecId }))
    {
        Console.WriteLine("group: LocId = {0}, SecId = {1}", group.Key.LocId, group.Key.SecId);
        foreach(Column column in group)
            Console.WriteLine("  item: StartElevation = {0}, EndElevation = {1}", column.StartElevation, column.EndElevation);
    }
