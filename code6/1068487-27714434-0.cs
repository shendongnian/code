    var result = xlinqInstruments
                     .Select(i=>new Instrument()
                                        {
                                           Name = i.Name, 
                                           Bars = i.Bars.Where(bar => bar.Time >= latestStartDate 
                                                                   && bar.Time <=earliestEndDate)
                                                        .ToList()
                                        });
