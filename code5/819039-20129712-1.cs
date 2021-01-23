    var myList = new[]
    {
        new { IsTop = false, S = 'a' },
        new { IsTop = true, S = 'b' },
        new { IsTop = false, S = 'c' },
        new { IsTop = true, S = 'd' },
        new { IsTop = false, S = 'e' },
    }.ToList();
    myList.TakeLastUntil(x => x.IsTop); // has d and e
