    db.LotteryOffer.Where(lo => lo.Id == <lotteryOfferId>)
        .SelectMany(lo => lo.LotteryDrawDates)
        .GroupBy( ldd => new { ldd.CreatedBy, ldd.ModifiedOn } )
        .Select( g => new
        {
            g.Key.CreatedBy,
            g.Key.ModifiedOn,
            TotalDrawDates = g.Count()
        }
        
