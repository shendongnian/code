    var customers = JsonConvert.DeserializeObject<RootObject>(e.Result);
    Listing ls = new Listing
    {
        ChannelName = customers.listings.First().ChannelName,
        NowShowing=customers.listings.First().NowShowing,
        Programs=customers.listings.First().Programs.Select(p=>new Program{
                                            ProgramName=p.ProgramName,
                                            ProgramTime=p.ProgramTime, 
                                            ProgramDetails = p.ProgramDetails
                                           })
    };
