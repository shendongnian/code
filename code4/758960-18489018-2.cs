    IEnumerable<string> commonSubset = allDevices.First().Interfaces;
    foreach (var interfaces in allDevices.Skip(1).Select(d => d.Interfaces))
    {
        commonSubset = commonSubset.Intersect(interfaces);
        if (!commonSubset.Any())
            break;
    }
