    var list = new List<Test>();
    for (int i = 0; i < 6; i++)
    {
        Test t = new Test();
        t.Click += delegate
        {
            click(a);
        };
        list.Add(t);
    }
    foreach (var t in list)
    {
        t.Click(null, null); // 6, 6, 6, 6, 6
    }
