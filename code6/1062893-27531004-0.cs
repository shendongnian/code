    var rule4Summed = (from r in ArkleSelection1.ArkleMarket1.Rule4sList
                      where r.Rule4ApplicationCode == "E" 
                            && r.DuductionEndTime > Bet.Betslip.DateScanned
                      group r by r.ArkleMarket1.MarketIdentifier into g
                      select new 
                      {
                         sumR4 = Sum(g.DeductionPercentForRunner),
                         dedEndTime = Max(g.DeductionEndTime),
                         dedStartTime = Min(g.DeductionStartTime)
                      }).FirstOrDefault();
