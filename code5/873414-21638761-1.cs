    List<Table> Tables = new List<int>();
    foreach (var s in ss)
    {
        Table t1 = new Table();
        ...
        _entities.Table.Add(t1);
        Tables.Add(t1);
    }
    _entities.SaveChanges();
    List<int> Ids = Tables.Select(t => t.ID).ToList();
