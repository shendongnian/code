    Dictionary<object, int> dict = new Dictionary<object, int>();
    object[] objs = new object[] { ... };
    
    for (int v = 0; v < objs.Length; v++)
    {
        object obj = objs[v];
        int count = dict.TryGet(obj, out count) ? count : 0;
        dict[obj] = count + 1;
    }
