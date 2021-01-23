    var list = new List<string>() { null, "test1", "test2" };
    for (int i = 0; i < list.Count; i++)
    {
        if (list[i] == null)
        {
            list[i] = "NULL";
        }
    }
