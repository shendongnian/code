    // An Alias, to be used later
    Person person = null;
    var childCriteria = QueryOver
        .Of<EmailClass>()
        // more QueryOver native style of a LIKE expression
        .WhereRestrictionOn(c => c.EmailAddress).IsLike(strSearch, MatchMode.Anywhere)
        // trick here
        // if we want to use the EXISTS later
        // we need to join outer and inner query here
        // and that's a place for outer query ALIAS
        .Where(c => c.PersonId == person.ItemId)
        .Select(c => c.PersonId); // must select something...
    var query = session
        // ALIAS expressing the outer query in action again
        .QueryOver<Person>(() => person)
        .WithSubquery
        .WhereExists(childCriteria)
        .Future();
