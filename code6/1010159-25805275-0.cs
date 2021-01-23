    select new People 
    {
      Name = a.Element("name").Value,
      Age = a.Element("age").Value,
      Hobby = a.Descendants("Hobby")
               .Select(x=> new Hobby
                          {
                            Title =x.Element("title").Value,
                            Description = x.Element("description").Value
                          }).ToList()
    }
