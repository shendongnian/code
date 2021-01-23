    var query = from witness in Context.witness
        where witness.DAFile.Id == id
        select new
        {
            WCFId = Guid.NewGuid(),
            witnessName = witness.Person.FirstName,
            Names = Context.witness.Select(w => w.FirstName),
        })
        .AsEnumerable() //do the rest in linq to objects
        .Select(witness => new WitnessInfo
        {
            WCFId = witness.WCFId,
            witnessName = witness.witnessName,
            AllNames = string.Join(", ", witness.Names),
        });
