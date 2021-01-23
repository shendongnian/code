    List<object[]> ProcessChunk(
        IStatelessSession session,
        int start,
        IEnumerable<Registro> currentChunk)
    {
        var disjunction = Restrictions.Disjunction();
        
        foreach (var item in currentChunk)
        {
            var restriction = Restrictions.Conjunction()
                .Add(Restrictions.Where<Registro>(t => t.Asunto == item.Asunto))
                /* etc, calling .Add(..) for every field you want to include */
                
            disjunction.Add(restriction);
        }
        
        return session.QueryOver<Registro>()
            .Where(disjunction)
            .SelectList(list => list
                .Select(t => t.Id)
                /* etc, the rest of the select list */
            .List<object[]>()
            .ToList();
    }
