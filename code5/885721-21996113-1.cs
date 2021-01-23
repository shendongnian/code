    private void foo<T>(IEnumerable<T> items, Func<T, Object>[] propertySelector) { }
    public void Main()
    {
        var peeps = new[]
        {
            new {FirstName = "Taco", LastName = "King"},
            new {FirstName = "Papa", LastName = "Georgio"}
        };
        foo(peeps, GetSelectors(peeps, an => an.FirstName, an => an.LastName));
    }
