    var SomeFunction = builder.Entity<SomeObject>().Collection.Action("SomeFunction");
    SomeFunction.Parameter<int>("take");
    SomeFunction.Parameter<int>("skip");
    SomeFunction.Parameter<int>("page");
    SomeFunction.Parameter<int>("pageSize");
    SomeFunction.ReturnsCollectionFromEntitySet<SomeObject>("SomeObjects");
