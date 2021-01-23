    using (var tx = statelessSession.BeginTransaction())
    {
        foreach (var person in persons)
        {
            try
            {
                statelessSession.Insert(person);
            }
            catch (GenericADONetException e)
            {
                // Further check that it's really caused by violating the unique constraing (database-specific) and handling the situation
            }
        }
        tx.Commit();
    }
