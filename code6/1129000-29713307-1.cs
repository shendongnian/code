    var query = dt.AsEnumerable()
        .GroupBy(row => new
                   {
                       Hour = row.Field<DateTime>("dateAndTime").Hour,
                       Code = row.Field<returnTypeOFCodeColumn>("Code")
                   })
        .Select(g => new 
                   {
                       Hour = g.Key.Hour,
                       Code = g.Key.Code, 
                       Count = g.Count()
                   }
            );
    foreach (var item in query)
    {
        //access properties here 
        //item.Hour, item.Code, item.Count  
    }
