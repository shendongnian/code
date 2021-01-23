    var lst = new List<Table>();
    
    lst.Add(new Table(){Date = new DateTime(2014,2,1),Category = "A"});
    lst.Add(new Table(){Date = new DateTime(2014,2,1),Category = "B"});
    lst.Add(new Table(){Date = new DateTime(2014,2,2),Category = "A"});
    lst.Add(new Table(){Date = new DateTime(2014,2,2),Category = "A"});
    
    
    lst.GroupBy(c => c.Date)
       .Select(c => new {
             Date = c.Key,
    		 CatA = c.Where(q => q.Category == "A").Count(),
    		 CatB = c.Where(q => q.Category == "B").Count(),
              })
       .Dump();
