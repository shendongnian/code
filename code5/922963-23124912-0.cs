    Person pers = null;
    Staff s = null;
    var subquery = QueryOver
        .Of<Staff>(() => s)
        .Where(() => s.Employee.Id == YYY)
        .And(() => s.Person.Id == XXX)
        // any SELECT clause, including the sub select, must return something
        .Select(sub => sub.Id)
        ;
    var query = session
        // let's use alias we've already declared above
        .QueryOver<Person>(() => pers)
        // the first condition
        .Where(
            // let's simplify the stuff 
            // instead of:   (IsMale OR (!IsMale AND exists)
            // use the same: (IsMale OR exists)
            Restrictions.Disjunction()
                .Add(() => pers.Male)  // alias pers
                .Add(Subqueries.Exists(subquery.DetachedCriteria))
        )
        // the second top level condition
        .And(() => pers.ID == XXX) // alias pers
        ;
