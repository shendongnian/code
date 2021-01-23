    class MyClass
    {
         private readonly Func<IDataContext> _contextFactory;
         public MyClass(Func<IDataContext> contextFactory)
         {
               _contextFactory = contextFactory;
         }
         public string MyMethod()
         {
               // 1. Is this needed?
               using (var u = _contextFactory())
               { 
                   var customers = u.Set<Customer>().OrderBy(o => o.Name);
                   // ........
               }
         }
