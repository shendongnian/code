    var list = new List<Test>();
    for (int i = 0; i < 6; i++)
    {
        int a = i; /* <--------------- THIS LINE HERE ------------------ */
        Test t = new Test();
        t.Click += delegate
        {
            click(a); // use the new variable here
        };
        list.Add(t);
    }
    foreach (var t in list)
    {
        t.Click(null, null); // 0, 1, 2, 3, 4, 5
    }
