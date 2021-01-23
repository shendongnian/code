    var models1 = .....// your collection of Models1
    
    var result = models1.Select(m1 => new 
        {
            m1.Id,
            m1.Name,
            pathIsDone = m1.Model2
                .Where(m2 => m2.IsDone)
                .Count(),
            pathIsnotDone = m1.Model2
                .Where(m2 => !m2.IsDone)
                .Count(),
        })
        .ToArray();
