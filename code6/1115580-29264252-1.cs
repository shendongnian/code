    public HttpResponseMessage Get()
            {
    
                var _americasPriorWeekThree = Convert.ToInt32((from contracts in allSignedContracts
                                                               where contracts.Region == "Americas"
                                                           select contracts.PriorWeek3).First());
.......
