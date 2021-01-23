    var lists = Enumerable.Range(0, 51).ToList();
    for (var i = 50; i != 0; --i)
    {
        if (lists[i] == 1 && i + 5 <= 50)
        {
            lists[i + 5] = lists[i + 5] + 2;
        }
    }
