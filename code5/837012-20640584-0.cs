        [TestInitialize]
        public void Initialize()
        {
            adapter = new Mock<SomeAdapter>();
            persons = new List<Person>();
            util = new SomeUtil(adapter);
        }
