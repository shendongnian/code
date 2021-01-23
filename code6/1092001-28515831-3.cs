    var Context = new EFContext();
    Context.YourTable.Remove(x=> x.Id == 1);
    Context.SaveChanges();
    // OR
    Context.Update((x=> x.Id == 1), new YourTable { ... });
    Context.SaveChanges();
