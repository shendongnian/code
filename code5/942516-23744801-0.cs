    var query = from foo in context.People
                select foo;
    if (state != null)
    {
        query = query.Where(p => p.State == state);
    }
    if (query != null) {
       if (teamType == "A")
       {
          var queryFinal = from foo in query
                           join foo2 in context.PeopleExtendedInfoA
          select new PeopleGrid()
          {
              Name = foo.Name,
              Address = foo.Address,
              Hobby = foo2.Hobby
          }
       }
       else
       {
          var queryFinal = from foo in query
                           join foo2 in context.PeopleExtendedInfoB
          select new PeopleGrid()
          {
              Name = foo.Name,
              Address = foo.Address,
              Hobby = foo2.Hobby
          }
       }
    }
