    List<string> ListZ = ListX.ToList();
    foreach (string x in ListX)
    {
        foreach (string y in ListY)
        {
            if (x.Contains(y))
                ListZ.Remove(x);
        }
    }
