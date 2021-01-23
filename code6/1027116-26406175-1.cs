     QueryContainer mainQuery = null; 
     if (!string.IsNullOrEmpty(searchOptions.SearchText))
     {
       var headline = Query<T>.Terms("headline", searchOptions.Headline.ToLower());
       var summary = Query<T>.Terms("fullSummary", searchOptions.Summary.ToLower());
       mainQuery &= (headline || summary);
     }
     if (searchOptions.FromDate != DateTime.MinValue && searchOptions.ToDate != DateTime.MinValue)
     {
         var dateFilter = Query<T>.Range(
                                    r => r.OnField("processedDate").GreaterOrEquals(searchOptions.FromDate, ElasticDateFormat).LowerOrEquals(searchOptions.ToDate, ElasticDateFormat));
         mainQuery &= dateFilter;
     }
     var result = Client.Search<T>(s => s.Query(mainQuery ).Size(Int32.MaxValue));
