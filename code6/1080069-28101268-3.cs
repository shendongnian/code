    using (var db = new YourDataContext())
    {
      // Since your DbSet isn't generic, you can can't use this:
      // db.Set("Namespace.EntityName").AsQueryable().Where(a=> a.HasSomeValue...
      // Your queries should also be string based.
      // Use the System.Linq.Dynamic nuget package/namespace
      var results = db.Set("Namespace.EntityName")
        .AsQueryable()
        .Where("SomeProperty > @1 and SomeThing < @2", aValue, anotherValue);
      // you can now iterate over the results collection of objects
    }
