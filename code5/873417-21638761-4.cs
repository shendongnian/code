    List<int> Ids = new List<int>();
    foreach (var s in ss)
    {
        Table t1 = new Table();
        ...
        _entities.Table.Add(t1);
        _entities.SaveChanges();
        Ids.Add(t1.ID);
    }
