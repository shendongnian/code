    List<int> ids = new List<int>(50);
    int total = userList.Count();
    Random r = new Random();
    while (ids.Count() < 50)
    {
        var next = r.Next(total);
        if (!ids.Contains(next))
            ids.Add(next);
    }
    var users = userList.Where(a => ids.Contains(a.ID));
