    int tasksToRunAtOnce = 3;
    var quotesTasks = new List<Task<IEnumerable<Quote>>(); 
    for(int i=0; i<10;i++)
    {
         quotesTasks.Add(GetQuotesAsync(i)); 
         if (i < tasksToRunAtOnce - 1)
             continue;
         var quotesFinished = await Task.WhenAny(quotesTasks);
         quotesTasks.Remove(quotesFinished);
 
         // process data for quotesTasks
         // update the UI
    }
    while(quoteTasks.Any())
    {
         var quotesFinished = await Task.WhenAny(quotesTasks);
         quotesTasks.Remove(quotesFinished);
 
         // process data for quotesTasks
         // update the UI
    }
