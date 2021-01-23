    Dictionary<string, decimal> names = new Dictionary<string, decimal>();
    // inside the loop
    decimal n = Convert.ToDecimal(split);
    if (names.ContainsKey(nameSplit))
    {
        names[nameSplit] += n;
    }
    else
    {
        names.Add(nameSplit, n);
    }
