    public static void Main()
    {
        var dict = new Dictionary<string, object>
        {
            {"Person.Name", "John Doe"},
            {"Person.Age", 27},
            {"Person.Address.House", "123"},
            {"Person.Address.Street", "Fake Street"},
            {"Person.Address.City", "Nowhere"},
            {"Person.Address.State", "NH"},
        };
        var hierarchicalDict = GetItemAndChildren(dict);
        string json = JsonConvert.SerializeObject(hierarchicalDict);
        Person person = JsonConvert.DeserializeObject<Person>(json);
        // person has all of the values you'd expect
    }
    static object GetItemAndChildren(Dictionary<string, object> dict, string prefix = "")
    {
        object val;
        if (dict.TryGetValue(prefix, out val))
            return val;
        else
        {
            if (!string.IsNullOrEmpty(prefix))
                prefix += ".";
            var children = new Dictionary<string, object>();
            foreach (var g in dict.Where(x => x.Key.StartsWith(prefix)).GroupBy(x => x.Key.Substring(prefix.Length).Split(new[] { '.' }, 2)[0]))
            {
                if (g.Count() == 1 && g.First().Key == prefix + g.Key)
                    children[g.Key] = dict[prefix + g.Key];
                else
                {
                    var nextOnes = g.Select(x => x.Key.Substring(prefix.Length).Split(new[] { '.' }, 3)[1]).Distinct().ToList();
                    foreach (var pair in nextOnes)
                    {
                        children[pair] = GetItemAndChildren(dict, prefix + g.Key + "." + pair);
                    }
                }
            }
            return children;
        }
    }
