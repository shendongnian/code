    Task<bool> [] recommendations = …;
    while(recommendations.Count > 0)
    { 
        Task<bool> recommendation = await Task.WhenAny(recommendations);    
        try
        {
            if (recommendation.Result) 
            {
                BuyStock(symbol);
            }
            break;
        }
        catch(AggregateException exc)
        {
            exc = exc.Flatten();
            if (exc.InnerExceptions[0] is WebException)
            {
                recommendations.Remove(recommendation);
            }
            else
            {
                throw;
            }
        }
    }
