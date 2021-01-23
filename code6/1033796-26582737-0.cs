    // Replace $value with value and remove all non-value strings
    var dollars = _DataCollection
        .Select(l => l.Select(str => str.Contains('$') ? str.Split('$')[1] : string.Empty));
    
    var newSumList = new List<double>();
        
    // Add all values in a new list
    for (int i = 0; i < _DataCollection[0].Count; i++)
    {
        double toAdd = 0;
        foreach (var entry in dollars)
        {
            // If entry is a value, parse it, 0 otherwise
            var value = entry.ElementAt(i) != string.Empty ? double.Parse(entry.ElementAt(i)) : 0;
            toAdd = toAdd + value;
        }
        newSumList.Add(toAdd);
    }
    newSumList.ForEach(Console.WriteLine);
