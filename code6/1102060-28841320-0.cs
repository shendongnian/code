    var categories = sortedData.GroupBy(d => d.Make)
                               .Select(g => new 
                               { 
                                   name = g.Key, 
                                   categories = g.Select(x => x.PartCode).ToArray() 
                               });
    var series = sortedData.GroupBy(d => d.InspectionCode)
                           .Select(g => new 
                           { 
                               name = g.Key, 
                               data = g.Select(x => x.Percentage).ToArray() 
                           });
    var categoriesAsJson = Newtonsoft.Json.JsonConvert.SerializeObject(categories);
    var seriesAsJson = Newtonsoft.Json.JsonConvert.SerializeObject(series);
