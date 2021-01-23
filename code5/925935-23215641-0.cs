      var dictionary = bookListRecord
        .GroupBy(g => g.CourseCode)
        .Select(g => new { g.Key, 
          AreaList = g.Select(c => c.Area).ToList(), 
          Area = g.Select(c => c.Area).FirstOrDefault() })
        .ToDictionary(g => g.Key);
