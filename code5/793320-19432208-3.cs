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
        var hierarchicalDict = GetItemAndChildren(dict, "Person");
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
            foreach (var child in dict.Where(x => x.Key.StartsWith(prefix)).Select(x => x.Key.Substring(prefix.Length).Split(new[] { '.' }, 2)[0]).Distinct())
            {
                children[child] = GetItemAndChildren(dict, prefix + child);
            }
            return children;
        }
    }
