    public IQueryable<Ask> GetAsksBySeller(int sellerId)
    {
        using (MarketContext _ctx = new MarketContext())
        {
            return _ctx.Asks
                   .Include("seller")
                   .Include("item")
                   .Where(s => s.seller.id == sellerId).AsQueryable();
        }
    }
