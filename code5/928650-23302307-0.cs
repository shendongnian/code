    public class Item
    {
        public string Blah { get; set; }
        public string Foo { get; set; }
    }
    [TestMethod]
    public void Test()
    {
        string propertyName = "Blah";
        System.Linq.Expressions.ParameterExpression arg = System.Linq.Expressions.Expression.Parameter(typeof(Item), "x");
    
        PropertyInfo pi = typeof(Item).GetProperty(propertyName,
        BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        System.Linq.Expressions.Expression expr = System.Linq.Expressions.Expression.Property(arg, pi);
        System.Linq.Expressions.LambdaExpression lambda = System.Linq.Expressions.Expression.Lambda(expr, arg);
        System.Linq.Expressions.Expression<Func<Item, string>> funcExpression = (System.Linq.Expressions.Expression<Func<Item, string>>)lambda;
    
        List<Item> test = new List<Item> { new Item { Blah = "Test", Foo = "Another" } };
        IQueryable<Item> query = test.AsQueryable();
        var result = query.Select(funcExpression).ToList();
    }
