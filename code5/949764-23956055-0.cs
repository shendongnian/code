    var entityModel = new ModelClass
    {
        Prop1 = model.Prop1,
        Prop2 = model.Prop2,
        // ...
    };
    context.ModelClass.Add(entityModel);
    context.SaveChanges();
