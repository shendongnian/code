    db.LotteryOffer.Where(lo => lo.Id == <lotteryOfferId>)
        .SelectMany(lo => lo.LotteryDrawDates)
        .Select( ldd => ldd.Lottery )
        .GroupBy( l => new { l.Name, l.CreatedBy, l.ModifiedOn } )
        .Select( g => new
        {
            g.Key.Name,
            g.Key.CreatedBy,
            g.Key.ModifiedOn,
            TotalDrawDates = g.Count()
        } );
        
