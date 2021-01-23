    // these are aliases, which we can/will use later, 
    // to have a fully-type access to all properties
    Person person = null;
    PartyContactMechanism partyContactMechanisms = null;
    ContactMechanism contactMechanism = null;
    // search params
    var firstName = ..;
    var lastName  = ..;
    var emailAddress = ..;
    var query = session.QueryOver<Person>(() => person)
        // the WHERE
        .Where(() => person.FirstName == firstName)
        // the And() is just more fluent eq of Where()
        .And(() => person.LastName == lastName)
        // this collection we will join as criteria
        .JoinQueryOver(() => person.PartyContactMechanism, () => partyContactMechanisms)
        // its property as alias
        .JoinAlias(() => partyContactMechanisms.ContactMechanism, () => contactMechanism )
        // final filter 
        .Where(() => contactMechanism.Code == emailAddress)
        // just one result
        .Take(1)
        ;
    var uniqueResult = query
        .List<Person>()
        .SingleOrDefault();
