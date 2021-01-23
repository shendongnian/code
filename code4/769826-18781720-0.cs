    if (!filteredColl.Any())
    {
        var ctx = new SomeCaptureContext(); // <== invented by the compiler
        ctx.date = new DateTime();
        filteredColl = coll.Where(ctx.SomePredicate).Select(x => x).ToList();
    }
