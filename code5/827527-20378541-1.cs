    var firstQuery = from witness in Context.witness
        where witness.DAFile.Id == id
        select new
        {
            WCFId = Guid.NewGuid(),
            witnessName = witness.Person.FirstName,
            Names = Context.witness.Select(w => w.FirstName),
        })
        .AsEnumerable(); //do the rest in linq to objects
    var finalQuery = from witness in firstQuery
        //do the string manipulation just once
        let allNames = string.Join(", ", witness.Names)
        select new WitnessInfo
        {
            WCFId = witness.WCFId,
            witnessName = witness.witnessName,
            AllNames = allNames,
        });
