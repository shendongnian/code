    var query = session.QueryOver<Entity>();
    var disjunction = new Disjunction();
    foreach (var s in listOfStrings)
    {
        disjunction.Add(Restrictions.On<Entity>(e => e.Name)
            .IsLike(s, MatchMode.Start));
    }
    var result = query.Where(disjunction).List();
