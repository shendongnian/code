    select new Summary
       {
           Population = g.Sum(x => (decimal)x.Population),
           State = g.Key.City,
           Gender = g.Key.Gender,
           AgeBracket = g.Key.AgeBracket
       }
