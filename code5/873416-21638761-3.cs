    List<Table> insertedTables = new List<int>();
    foreach (var s in ss)
    {
        Table t1 = new Table();
        ...
        _entities.Table.Add(t1);
        insertedTables.Add(t1);
    }
    _entities.SaveChanges();
    List<int> Ids = insertedTables.Select(t => t.ID).ToList();
