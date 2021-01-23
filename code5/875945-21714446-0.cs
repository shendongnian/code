    List<string> markets = getAllMarkets();
    var marketList = new List<string>();
    marketList.Add("San");
    markets = markets.Where(marketList.Contains);
    for(int i = 0; i < marketList.Count; i++)
    {
        for(int a = 0; a < marketList.Count; a++)
        {
            markets[a] = markets[i].Where(marketList.Contains);
        }
     }
