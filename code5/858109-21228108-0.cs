    using(var ctx = new MyContext())
    {
        var entity = ctx.Table.First(t => t.Id == myId);
        entity.Prop1 = "newValue";
        entity.Prop2 = 23;
    
        ctx.SaveChanges();
    }
