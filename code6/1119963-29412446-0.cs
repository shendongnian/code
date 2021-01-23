    List<string> one = new List<string>(new[] {"Test 1", "Test 1", "Test 2"});
    List<string> two = new List<string>();
    var toRemove = new List<string>();
    foreach (var value in one)
    {
        if(value.Equals("Test 1"))
        {
            toRemove.Add(value);
            two.Add(value);
        }
    }
    foreach (var value in toRemove)
    {
        one.Remove(value);
    }
