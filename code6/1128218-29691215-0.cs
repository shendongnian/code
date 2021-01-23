     List<CountryMobility> inboundStudents = new List<CountryMobility>{ 
                new CountryMobility { countryCode="EG", inbound=2, outbound = 0},
                new CountryMobility { countryCode="CA", inbound=3, outbound = 0},
                new CountryMobility { countryCode="CH", inbound=5, outbound = 0}};
    
            List<CountryMobility> outboundStudents = new List<CountryMobility>{ 
                new CountryMobility { countryCode="PE", inbound=0, outbound = 1},
                new CountryMobility { countryCode="CA", inbound=0, outbound = 4},
                new CountryMobility { countryCode="CH", inbound=0, outbound = 5}};
    
                    var joinedList = inboundStudents.Concat(outboundStudents).GroupBy(item => new { item.countryCode});
                    var result = joinedList.Select(x => new 
                    {
                        countryCode = x.Key.countryCode,
                        inbound = x.Sum(i => i.inbound),
                        outbound = x.Sum(i => i.outbound)
                    });
