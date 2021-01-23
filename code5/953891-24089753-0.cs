    // connect to context
    _ctx.Cars.Attach(car);
    // check for updated info
    var entry = _ctx.Entry(car);
    entry.Property(e => e.NumberOfDoors).IsModified = true;
    // save changes
    _ctx.SaveChanges();
