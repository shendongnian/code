    var dateVals = new[] { 
        new DateValue(DateTime.Today.AddDays(10), 1) ,new DateValue(DateTime.Today, 3) ,new DateValue(DateTime.Today.AddDays(4), 7) 
    };
    var dvCollection = new DateValueCollection(dateVals, false);
    DateValue nearest = dvCollection.GetNearest(DateTime.Today.AddDays(1));
