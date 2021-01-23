    using(var context = new ...())
    {
        var EditedObj = context
            .Obj
            .Where(x => x. ....)
            .First();
        NewObj.Id = EditedObj.Id; //This is important when we first create an object (NewObj), in which the default Id = 0. We can not change an existing key.
        context.Entry(EditedObj).CurrentValues.SetValues(NewObj);
        context.SaveChanges();
    }
