    var houseName = "...";
    var roomNumber = ...;
    // prefilter houses
    // first change fromt he question above here is
    // that we instead of session.QueryOver
    // have to use detached version: QueryOver.Of
    var subquery = QueryOver.Of<House>()
        .Where(h => h.Name == houseName)
        // each subquery also MUST return something
        // here the ID - house ID,  to be later use for match
        .Select(x => x.ID)
        ;
    Room room = null;
    var query = session.QueryOver<Room>(() => room)
        .Where(r => r.ContactPositionId == roomNumber)
        // take rooms, which house id fits
        .WithSubquery
            // the room's property HouseID
            .WhereProperty(() => room.HouseId)
            // IS IN (...)
            .In(subquery)
        ;
    // later the list
    var list = query
        .Take(10)
        .List<Room>();
