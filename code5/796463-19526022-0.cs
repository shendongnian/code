    dt.AsEnumerable()
    .GroupBy(r => r.Field<string>("Agency"))
    .Select(g => 
        new AgencyDto { 
              Agency = g.Key,
              Contacts = g.GroupBy(r1 => r1.Field<string>("POC"))
                .Select(g1 => 
                  new ContactDto { 
                        Contact = g1.Key, 
                        Groups = string.Join(",", g1.Select(r2 => r2.Field<string>("POC_Name")))
                      })
            })
