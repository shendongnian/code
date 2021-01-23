    Task<bool> recommendation = await Task.WhenAny(recommendations);    
    if(!recommendation.IsFaulted)
    {
        if (await recommendation) BuyStock(symbol);
        break;
    }
    else
    {
        if(recommendation.Exception.InnerExceptions[0] is WebException)
        {
            recommendations.Remove(recommendation);
        }
        else
        {
            throw recommendation.Exception.InnerExceptions[0];
        }
    }
