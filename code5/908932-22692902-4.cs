    public class DataAccess
    {
        public PricelessBond GetBondWithoutPrice(int id)
        {
            return db.Bonds
                .Select(b => new PricelessBond
                {
                    ID = b.ID
                })
                .Single(b => b.ID == id);
        }
        public Bond GetBond(int id)
        {
            return db.Bonds
                .Select(b => new Bond
                {
                    ID = b.ID,
                    Prices = b.Prices.Select(p => new Price{}).ToArray()
                })
                .Single(b => b.ID == id);
        }
    }
