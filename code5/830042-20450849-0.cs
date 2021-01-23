    Set<int> s = new HashSet<int>();
    for (int i in malouda)
    {
        if (s.Contains(i))
        {
            Console.WriteLine(i);
        }
        else
        {
            s.Add(i);
        }
    }
