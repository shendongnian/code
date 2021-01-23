    class Pushpin
    {
        public Pushpin() { }
        // More Pushpin-related members and methods here
    }
    class Test
    {
        public Test(string name) { Name = name; }
        public string Name { get; set; }
        // More Test-related members and methods here
    }
    class SO23174064
    {
        Dictionary<string, Pushpin> pushpins = new Dictionary<string, Pushpin>();
        public Dictionary<string, Pushpin> CreatePushpins(IEnumerable<Test> tests)
        {
            foreach (Test test in tests)
                pushpins[test.Name] = new Pushpin();
            return pushpins;
        }
    }
