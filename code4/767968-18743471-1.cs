    [Test]
    public void SchemaShouldMatchMappings()
    {
        // `GetAllClassMetadata` returns a collection of all of the mapped entities.
        foreach (var entry in _sessionFactory.GetAllClassMetadata())
        {
            // Build a query that fetches this entity...
            _session.CreateCriteria(entry.Value.EntityName)
                // ... but tell it to just check the schema and not actually bring any back.
                .SetMaxResults(0)
                // Execute the query.
                .List();
        }
    }
