    var quotesTasks = new List<Task<IEnumerable<Quote>>(); 
    for(int i=0; i<10;i++)
    {
         quotesTasks.Add(GetQuotesAsync(i)); 
         if (i == 0)
             continue;
         var quotesFinished = await Task.WhenAny(quotesTasks);
         quotesTasks.Remove(quotesFinished);
 
         // process data for quotesTasks
         // update the UI
    }
    var final = await quotesTasks[0];
    // Process final data too...
