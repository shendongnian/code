    IEnumerable<string> commonSubset = new List<string>(allDevices.First().Interfaces);
    foreach (List<string> interfaces in allDevices.Skip(1).Select(d => d.Interfaces))
    {
        commonSubset = commonSubset.Intersect(interfaces);
        if (!commonSubset.Any())
            break;
    }
