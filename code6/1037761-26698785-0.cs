        var dic = new Dictionary<string, int>();
        // calculate sum of all values in dictionary
        var sum = dic.Sum(x => x.Value);
        // divide each value by sum
        foreach (var key in dic.Keys)
        {
            dic[key] = dic[key] / sum;
        }
        // multiply each value by 3
        foreach (var key in dic.Keys)
        {
            dic[key] = dic[key] * 3;
        }
