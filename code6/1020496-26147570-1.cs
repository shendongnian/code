    using (ISession session = SessionFactory.OpenSession())
    {
        var criteria = session.CreateCriteria<T>();
        
        // I. use criteria to find what should be changed    
        foreach (var cri in lstCriterios)
        {
            criterio.Add(cri);
        }
        
        // II. load the searched
        var list = session.List<T>();
        // III. update entities in runtime
        foreach(var entity in list)
        {
           entity.Property1 = newValue1;
           entity.Property2 = newValue2;
           ...
        }
        // IV. UPDATE == flush
        session.Flush();
    }
