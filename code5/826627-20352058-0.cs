    var list = new[] { "Hello", "World", "Example" };
    
    var dictionary = new Dictionary<string, Func<IEnumerable<string>, IEnumerable<string>>>();
    
    dictionary.Add("alphabet", a => a.OrderBy(b => b));
    dictionary.Add("length", a => a.OrderBy(b => b.Length));
    
    var result = dictionary["alphabet"](list);
