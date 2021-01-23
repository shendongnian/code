    [TestClass]
    public class AggTest
    {
        private ISource Isource;
        private Agg agg;
        [TestInitialize]
        public void SetUp()
        {
            Isource = MockRepository.GenerateMock<ISource>();
            agg = new Agg(new [Isource]);
        }
        [TestMethod]
        public void GetAll()
        {
            Isource.Stub(x => x.GetCurr()).
                Return(new JToken());
            var jObject = agg.GetAll();
            Assert.IsNotNull(jObject);
            // Do your assertion that all JProperty objects are in the jObject
            // I don't know the syntax
        }
    }
