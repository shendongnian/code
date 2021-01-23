    //Get the first record from Histories where the product name is "Magic beans" and populate a new ReportRecord with those values
    ReportRecord rep = Histories.Select(rec => new ReportRecord()
                                {
                                    ProductName = rec.Name,
                                    Total = rec.AdvanceTotal,
                                    BidTotal = rec.LiveTotal
    
                                }).Where(w => w.Name == "magic beans")
                                  .First();
