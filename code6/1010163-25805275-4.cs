    var person = from a in xml.Descendants("person")
                  select new People 
                  {
                    Name = a.Element("name").Value,
                    Age = a.Element("age").Value,
                    Hobby = a.Descendants("hobby")
                              .Select(x=> new Hobbies
                                           {
                                             Title =x.Element("title").Value,
                                             Description = x.Element("description").Value
                                           }).ToList()
                   };
