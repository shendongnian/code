    var total = dictionary.Sum(e => e.Value);
    var cutoff = total * 0.5;
    var sum = 0;
    var pairs = new List<KeyValuePair<string, int>>();
    foreach (var pair in dictionary.OrderByDescending(e => e.Value))
    {
         sum += pair.Value;
         pairs.Add(pair);
         if (sum > cutoff)
             break;
    }
            
    dictionary = pairs.ToDictionary(pair => pair.Key, pair => pair.Value);
