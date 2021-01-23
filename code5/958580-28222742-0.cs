    var dto = iqueryable.ToInjectable().Select(d => new DTO() 
    {
        X = d.X,
        Y = d.Y,
        Z = d.CustomExpression()
    } 
    public static class CustomExpressions
    {
        [InjectLambda]
        public static string CustomExpression(this EntityTypeFromIQueryable value)
        {
            // this function is just a placeholder
            // you can implement it for non LINQ use too...
            throw new NotImplementedException();
        }
        public static Expression<Func<EntityTypeFromIQueryable, string>> CustomExpression()
        {
            return x => x.Blah
        }
    }
