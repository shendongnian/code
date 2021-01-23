    Dictionary<string, int> names = new Dictionary<string, int>();
    // inside the loop
    int n = Convert.ToInt32(split);
    if (names.ContainsKey(nameSplit))
    {
        names[nameSplit] += n;
    }
    else
    {
        names.Add(nameSplit, n);
    }
