    public class FooBar
    {
        private Fixture fixture;
        private Mock<BookingRepository> bookingRepository; 
    
        public FooBar()
        {
            fixture = new Fixture();
            bookingRepository= new Mock<BookingRepository>();
        }
    
        public void TestInitialize()
        {
            var sprocObject = fixture.Create<DbObject>();
            
            bookingRepository.Setup(x => x.GetAllBookings(It.IsAny<string>())).Returns(sprocObject);
        }
        
        // Unit tests
    }
