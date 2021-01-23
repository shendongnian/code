    using (var Model = new MK3Entities())
    {
        DynamicHelper Dh = new DynamicHelper();
        var TOrigin = Model.Titles
          .Where("ID > 19632")
          .Select(t => new { ID = t.ID, ExtTitleID = t.ExtTitleId })
          .Take(10)
          .ToList() // Execute SQL Statement
          .Select(t => new {ID = t.ID, Link = nh.FormattedLink(ExtTitleID, ID)})
          .ToList();
              
        Console.ReadKey();
    } 
