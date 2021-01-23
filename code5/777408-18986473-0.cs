    var bytes = new List<byte>(10000);
    int size = 100;
    var lists = new List<List<byte>>(size);
    for (int i = 0; i < bytes.Count; i += size)
    {
            var list = new List<byte>();
            list.AddRange(bytes.GetRange(i, size));
            lists.Add(list);
    }
