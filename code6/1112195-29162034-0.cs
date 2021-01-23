    using (var session = _documentStore.OpenSession())
    {
        var query = session.Advanced.DocumentQuery<Contact>()
            .WhereStartsWith(x => x.FirstName, "searchArgument1");
        if(hasSearchArgument2)
            query = query.WhereStartsWith(x => x.FirstName, "searchArgument2");
        var contacts = query.ToList();
    }
