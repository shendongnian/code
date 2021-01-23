    var query = Query.And(
        Query<Band>.EQ(b => b.Name == "Rush"),
        Query<Band>.EQ(b => b.Members[-1].FirstName == "Geddy"));
    var update = Update<Band>
        .Set(b => b.Members[-1].Instrument, "Keyboards")
        .Set(b => b.Members[-1].LastName, "Leex");
