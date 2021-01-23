    // for when you're creating new entities
    var newFoo = new Foo();
    newFoo.Name = "A Name";
    using(var context = new MyContext())
    {
        context.Add(newFoo);
        InsertOrUpdate(context. newFoo);
    }
    // ...
    // for when you're using existing entities
    // you have an ID from somewhere in variable "id"
    using (var context = new MyContext())
    {
        var existingFoo = context.Find(id);
        if (existingFoo != null)
        {
            existingFoo.Name = "ChangedTheName";
            InsertOrUpdate(context, existingFoo);
        }
    }
