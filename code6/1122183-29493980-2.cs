    db.User
      .Where(p => p.DateOfBirth != null)
      .GroupBy(p => p.DateOfBirth.Value.Year)
      .Select(g => 
       {
           int age = DateTime.Now.Year - g.Key;
           int range = (age / 5) - 3; //Assumes that everything is at least age > 15
           if(range % 2 == 1)
                range -= 1; //to make sure we group 10s not 5s
           return new { Age = DateTime.Now.Year - g.Year), Count = g.Count(), Range = range } //notice you'll need to figure out how to get the year into the grouping, the key isn't going to help you here
       })
      .GroupBy(a => g.Range)
      .Select(g => new {RangeValue = g.Range, Count = g.Count()});
