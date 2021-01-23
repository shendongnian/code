    db.LotteryOffer.Where(lo => lo.Id == <lotteryOfferId>)
        .SelectMany(lo => lo.LotteryDrawDates)
        .Select( ldd => ldd.Lottery )
        .GroupBy( l => new { l.CreatedBy, l.ModifiedOn } )
        .ToArray()
        .Select( g => new
        {
            g.Key.CreatedBy,
            g.Key.ModifiedOn,
            TotalDrawDates = g.Count()
        } );
        
