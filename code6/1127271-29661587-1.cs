    public class Bids
    {
        public int Id { get; set; }
        public double Price { get; set; }
    }
    public class BidSection
    {
        public int BidId { get; set; }
    }
    public class SellingOptions
    {
        public int BidId { get; set; }
        public int Quantity { get; set; }
    }
    public class Item
    {
        public int ItemId { get; set; }
        public BidSection FWOBidSection { get; set; }
    }
    public class ConditionalJoin
    {
        public bool jOpt1 { get; set; }
        public bool jOpt2 { get; set; }
        public ConditionalJoin(bool _joinOption1, bool _joinOption2)
        {
            jOpt1 = _joinOption1;
            jOpt2 = _joinOption2;
        }
        public class FBandSo
        {
            public Bids FWOBids { get; set; }
            public SellingOptions FWOSellingOptions { get; set; }
        }
        public class FBandI
        {
            public Bids FWOBids { get; set; }
            public Item FWOItem { get; set; }
        }
        public void Run()
        {
            var fwoBids = new List<Bids>();
            var sellingOptions = new List<SellingOptions>();
            var fwoItems = new List<Item>();
            fwoBids.Add(new Bids() { Id = 1, Price = 1.5 });
            sellingOptions.Add(new SellingOptions() { BidId = 1, Quantity = 2 });
            fwoItems.Add(new Item() { ItemId = 10, FWOBidSection = new BidSection() { BidId = 1 } });
            IQueryable<Bids> fb = fwoBids.AsQueryable();
            IQueryable<SellingOptions> so = sellingOptions.AsQueryable();
            IQueryable<Item> i = fwoItems.AsQueryable();
            IQueryable<FBandSo> FBandSo = null;
            IQueryable<FBandI> FBandI = null;
            if (jOpt1)
            {
                FBandSo = from f in fb
                          join s in so on f.Id equals s.BidId
                          select new FBandSo()
                          {
                              FWOBids = f,
                              FWOSellingOptions = s
                          };
            }
            if (jOpt2)
            {
                FBandI = from f in fb
                         join y in i on f.Id equals y.FWOBidSection.BidId
                         select new FBandI()
                         {
                             FWOBids = f,
                             FWOItem = y
                         };
            }
            if (jOpt1 && jOpt2)
            {
                var query = from j1 in FBandSo
                            join j2 in FBandI
                            on j1.FWOBids.Id equals j2.FWOItem.FWOBidSection.BidId
                            select new
                            {
                                FWOBids = j1.FWOBids,
                                FWOSellingOptions = j1.FWOSellingOptions,
                                FWOItems = j2.FWOItem
                            };
            }
        }
    }
