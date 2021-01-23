    foreach (var p1 in p)
    {
        var p2 = p1;
        p1.MouseClick += delegate { p2.Hide(); };
    }
