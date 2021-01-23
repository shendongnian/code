    public class FooBar
    {
        private Fixture fixture;
        private Mock<FooBarRepository> fooBarRepository; 
    
        public FooBar()
        {
            fixture = new Fixture();
            fooBarRepository = new Mock<IBusinessRulesFactory>();
        }
    
        public void TestInitialize()
        {
            var sprocObject = fixture.Create<DbObject>();
            
            fooBarRepository.Setup(x => x.GetAllBookings(It.IsAny<string>())).Returns(sprocObject);
        }
        
        // Unit tests
    }
