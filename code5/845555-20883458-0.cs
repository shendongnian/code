    public class TestIndex : AbstractIndexCreationTask<TestDocument, TestIndex.IndexEntry>
    {
        public class IndexEntry
        {
            public IList<string> LocationCodes { get; set; }
            public IList<string> ColorCodes { get; set; }
        }
        public TestIndex()
        {
            Map = testDocs =>
                from testDoc in testDocs
                select new
                {
                    LocationCodes = testDoc.Locations.Select(x=> x.Code),
                    ColorCodes = testDoc.Colors.Select(x=> x.Code)
                };
        }
    }
