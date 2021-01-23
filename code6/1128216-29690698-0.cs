    public class CountryMobility
    {
        public string countryCode { get; set; }
        public int inbound { get; set; }
        public int outbound { get; set; }
    }
    public static class JoinedMobilityQuery
    {
        static CountryMobility[] inbound = {
            new CountryMobility() { countryCode = "EG", inbound = 2 },
            new CountryMobility() { countryCode = "CA", inbound = 3 },
            new CountryMobility() { countryCode = "CH", inbound = 5 },
        };
        static CountryMobility[] outbound = {
            new CountryMobility() { countryCode = "PE", outbound = 1 },
            new CountryMobility() { countryCode = "CA", outbound = 4 },
            new CountryMobility() { countryCode = "CH", outbound = 6 },
        };
        static IQueryable<CountryMobility> Inbound()
        {
            return inbound.AsQueryable();
        }
        static IQueryable<CountryMobility> Outbound()
        {
            return outbound.AsQueryable();
        }
        public static void Run()
        {
            var transfers = from t in Inbound().Concat(Outbound())
                            group t by t.countryCode into g
                            select new CountryMobility() {
                                countryCode = g.Key,
                                inbound = g.Sum(x => x.inbound),
                                outbound = g.Sum(x => x.outbound),
                            };
            foreach (var transfer in transfers)
                Console.WriteLine("{0}\t{1}\t{2}", transfer.countryCode, transfer.inbound, transfer.outbound);
        }
    }
