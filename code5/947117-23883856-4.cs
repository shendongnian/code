    List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();
    for (int i = 0; i < intx.Length - 1; i++)
    {
        for (int ii = i + 1; ii < intx.Length; ii++)
        { 
           if(i + ii == 10)
               pairs.Add(Tuple.Create(i, ii));
        }
    }
