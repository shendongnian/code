    public ActionResult Save(Model1 model1)
    {
        using (var ctx = new MyDbContext())
        {
            ctx.Model1.Attach(model1);
            var entry = ctx.Entry(model1);
            entry.Property(e => e.Prop1).IsModified = true;
            entry.Property(e => e.Prop2).IsModified = true;
            ...
            ctx.SaveChanges();
        }
    }
