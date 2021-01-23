    var someEntity =
                    context.Set<SomeEntity>.FirstOrDefault(
                        x => x.EntityId == 2) ?? new ProcedureBillingOptionRecord();
    context.Entry(someEntity).State = someEntity.EntityId == 0 ? 
                                       EntityState.Added : 
                                       EntityState.Modified; 
    someEntity.Foo="foo";
    someEntity.Bar="Bar";
    //...
    context.SaveChanges(); 
