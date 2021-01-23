        public class ZonesFactory
        {
            private readonly int defaultMinScore;
            public ZonesFactory(int defaultMinScore)
            {
                this.defaultMinScore = defaultMinScore;
            }
            public Zones CreateZones()
            {
                return new Zones(defaultMinScore);
            }
        }
    Note that here I'm assuming you also create a new constructor for `Zones` which takes the `minScore` as a parameter. I suggest you get rid of the `setMinScore` method (which violates .NET naming conventions apart from anything else).
