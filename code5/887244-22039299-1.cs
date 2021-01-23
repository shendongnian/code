    [TestClass]
    public class OfficeUnitTest
    {
        private MyOfficeService service;
        [TestInitialize]
        public void Setup()
        {
            var officeRepository = new Mock<IOfficeRepository>();
            
            var office = new List<Office>();
            office.Add(new Office{ Id = 1 });
            officeRepository.Setup(m => m.GetAll()).Returns(office.AsQueryable());
            this.service = new MyOfficeService(officeRepository.Object);
        }
        [TestMethod]
        public void TestGetById()
        {
            Assert.IsNotNull(service.GetOffice(1));
            // my mock will never return a value for 2
            Assert.IsNull(service.GetOffice(2));
        }
    }
