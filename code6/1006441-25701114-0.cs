    [TestMethod]
    public void StringyAndDangerous()
    {
        var fakePersonDbSet = new List<Person> { new Person() { FirstName = "Some", LastName = "Guy" } }.AsQueryable();
        var attributes = new string[] { "FirstName", "LastName" };
        var selectedFields = String.Join(",", attributes);
        var exprssion = string.Format("new ({0})", selectedFields);
        var result = fakePersonDbSet.Select(exprssion, attributes).Cast<dynamic>().First();
    }
