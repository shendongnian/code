	var stringValues = from p in persons
 					   join s in stringProperties on p.ID equals s.PersonID
					   group s by p.Code into g 
					   select new
					   {
						   Code = g.Key,
						   FirstName = g.Where(s => s.Name == "FirstName").First().Value,
						   LastName = g.Where(s => s.Name == "LastName").First().Value,
					   };
