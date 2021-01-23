    void foo()
    {
        string firstSwitch = Console.ReadLine().ToLower();
        string result;
        if (firstSwitch == "chooserandom")
        {
            result = _nameLookup[_rand.Next(_nameLookup.Count)];
        }
        else if (!_nameLookup.TryGetValue(firstSwitch, out result))
        {
            result = _nameLookup["default"];
        }
        Console.WriteLine(result);
    }
