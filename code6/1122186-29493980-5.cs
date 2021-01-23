    db.User
      .Where(p => p.DateOfBirth != null)
      .GroupBy(p => p.DateOfBirth.Value.Year)
      .Select(g => 
       {
           int age = DateTime.Now.Year - g.Key;
           int range = (age / 5) - 3; //Assumes that everything is at least age > 15
           if(range % 2 == 1)
                range -= 1; //to make sure we group 10s not 5s
           return new { Age = age, Count = g.Count(), Range = range } 
       })
      .GroupBy(a => g.Range)
      .Select(g => new {RangeValue = g.Range, Count = g.Count()});
