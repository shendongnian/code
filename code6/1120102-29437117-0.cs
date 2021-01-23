     Map = docs =>
                    from doc in docs
                    select new
                    {
                        doc.Id,                   
                        _ = SpatialIndex.Generate(doc.Latitude, doc.Longitude)
                    };
      var results = session
                        .Advanced
                        .LuceneQuery<Class>("IndexName")
                        .WithinRadiusOf(query.SearchRadius, query.Latitude, query.Longitude, SpatialUnits.Miles)                        
                        .SortByDistance()
