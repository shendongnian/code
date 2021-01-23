    // I. the outer query ALIAS
    Employee emplyoee = null;
    // II. the subquery - using the alias
    var subQuery = QueryOver.Of<Contact>()
        .Select(x => x.ID)
        .Where(x => x.Related.ID == emplyoee.ID); // use alias
    // III. declare the outer query and use the above alias
    var query = session.QueryOver<Employee>(() => emplyoee) // declare alias
        .WithSubquery
            .WhereExists(subQuery); // put both together
