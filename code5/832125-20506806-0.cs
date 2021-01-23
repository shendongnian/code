    public IEnumerable<Redemption> Get(int ID, int CountToFetch)
    {
        var redempts = redemptions.Where(i => i.Id > ID).Take(CountToFetch).ToList();
        if (redemptions.Any())
        {
            return redempts;
        }
        return null;
    }
