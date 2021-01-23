    var a = context.A.Include(a => a.Bs).First();
    foreach(var b in a.Bs)
    {
        context.Entry(b).State = EntityState.Deleted;
    }
    context.Entry(a).State = EntityState.Deleted;
    context.SaveChanges();
