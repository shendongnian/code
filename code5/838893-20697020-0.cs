    IQueryOver<Contact,Contact> rootQuery = session  // here we have Contact query
        .QueryOver<Contact>();                          
    IQueryOver<Contact, Employee> emplQueryOver = rootQuery
        .JoinQueryOver<Employee>(c => c.Parnter);       // here we work with its Parnter
    IQueryOver<Contact, Employee> creatorQueryOver = emplQueryOver
        .JoinQueryOver<Employee>(e => e.Creator);       // here we have creator of Parnter
