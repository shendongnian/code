    var words = "Smith is very cool member of Smith Company"
        .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    var dic = new Dictionary<string, double>();
    foreach (string word in words)
    {
        if (dic.ContainsKey(word))
            dic[word]++;
        else
            dic[word] = 1;
    }
    var sum = dic.Sum(x => x.Value);
    var result = dic.Values.Aggregate(1.0, (current, item) => current * (item / sum));
