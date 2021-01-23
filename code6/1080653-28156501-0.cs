    using (ServiceContext svcContext = new ServiceContext(_serviceProxy))
         {
           var query_where3 = from c in svcContext.ContactSet
                             join a in svcContext.AccountSet
                             on c.ContactId equals a.PrimaryContactId.Id
                             where c.FullName == "Café" || c.FullName == "Cafe"
                             select new
                             {
                              account_name = a.Name,
                              contact_name = c.LastName
                             };
    }
