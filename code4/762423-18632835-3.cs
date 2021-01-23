    using (var session = sessionFactory.OpenSession())
    {
        session.EnableFilter("SpecificCategory");
        session.EnableFilter("SpecificLanguage");
    }
