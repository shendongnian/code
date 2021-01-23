    if (keywords.Count == 1)
    {
        Results = Results.Where(x => x.DB_Auction.Description.Contains(keywords[0]));      
    }
    else if (keywords.Count > 1)
    {
        Results = Results.Where(x => x.DB_Auction.Description.Contains(keywords[0])); 
        foreach (string keyword in keywords)
        {
            Results = Results.Where(x => x.DB_Auction.Description.Contains(keyword));
        }  
    }
