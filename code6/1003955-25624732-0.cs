    Task<bool> recommendation = await Task.WhenAny(recommendations);    
    if(!recommendation.IsFaulted)
    {
        if (await recommendation) BuyStock(symbol);
        break;
    }
    else
    {
        if(recommendation.Exception is WebException)
        {
            recommendations.Remove(recommendation);
        }
        else
        {
            throw recommendation.Exception;
        }
    }
