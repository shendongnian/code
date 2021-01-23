    var dict = Yours.ToDictionary(y => y.Name);
    foreach (var m in Mine) {
        Account y;
        if (dict.TryGetValue(m.Name, out y))
            Ours.Add(new Account { ID = y.ID, Name = m.Name, Value = m.Value });
        else
            Ours.Add(m);
    }
