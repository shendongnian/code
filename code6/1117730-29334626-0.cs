    public class FooGuid
    {
        [Key] public Guid Url { get; set; }
        public Foo Foo { get; set; }
    }
    Guid urlpart = ...
    Foo foo = dbContext.FooGuids
                  .Where(f => f.Url == urlpart)
                  .Select(f => f.Foo)
                  .Single();
