    [TestMethod]
    public void SlowerButSafer()
    {
        var fakePersonDbSet = new List<Person> { new Person() { FirstName = "Some", LastName = "Guy" } }.AsQueryable();
        var attributes = new string[] { "FirstName", "LastName" };
        var personPropertylist = CovertToKeyValuePair(fakePersonDbSet.First())
            .Where(c=> attributes.Contains(c.Key))
             .ToArray();            
    }
    private IEnumerable<KeyValuePair<string, object>> CovertToKeyValuePair<T>(T @object)
    {
        var result = new List<KeyValuePair<string, object>>();
        var properties = typeof (T).GetProperties();
        foreach (var property in properties)
        {
            result.Add(new KeyValuePair<string, object>(property.Name, property.GetValue(@object, null)));
        }
        return result;
    }
