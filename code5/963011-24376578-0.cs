    var pagerObjectGrouped = pagerObject.GroupBy(pg => pg.PagerPhoneNumber)
        .Select(s => new ModlPagers {
        Holder = s.First().Holder, 
        RecordId = s.First().RecordId, 
        PagerPhoneNumber =  s.First().PagerPhoneNumber, 
        Sum = s.Sum(a => a.Amount)}).ToList();  
