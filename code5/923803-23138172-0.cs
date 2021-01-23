    List<int> ints = new List<int>();
    Array.ForEach(strMyList.Split(','), s =>
        {
            int i;
            if (int.TryParse(s, out i)){ ints.Add(i);}
        });
