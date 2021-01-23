    public IQueryable<Lottery> GetLotteriesByLotteryOfferId(int lotteryOfferId)
    {
        return this.db.LotteryOffers
                                    .Where(lo => lo.Id == lotteryOfferId)
                                    .SelectMany(lo => lo.LotteryDrawDates)
                                    .Select(ldd => ldd.Lottery)
                                    .GroupBy(s => new { s.Name, s.CreatedBy, s.ModifiedOn, s.Id })
                                    .AsEnumerable()
                                    .Select(g => new Lottery
                                                    {
                                                        Name = g.Key.Name,
                                                        CreatedBy = g.Key.CreatedBy,
                                                        ModifiedOn = g.Key.ModifiedOn,
                                                        Id = g.Key.Id
                                                    });
    }
