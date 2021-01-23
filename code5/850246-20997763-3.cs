    var customers = JsonConvert.DeserializeObject<RootObject>(e.Result);
    Listing ls = new Listing
    {
        ChannelName = customers.listings.First().ChannelName,
        NowShowing=customers.listings.First().NowShowing,
        Programs=Enumerable.Range(1,10).Select(p=>new Program{
                                            ProgramName="generated name",
                                            ProgramTime="generated time", 
                                            ProgramDetails = "generated details"
                                           })
    };
