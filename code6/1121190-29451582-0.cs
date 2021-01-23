    [TestFixture]
    public class DonorManagementTests
    {
        private Mock<IValidation> _mockValidation;
        private DonorManagement _donorManagement;
        [SetUp]
        public TestInit()
        {
            _mockValidation = new Mock<IValidation>();
            _donorManagement = new DonorManagement(_mockValidation.Object);
        }
        [Test, Description("View correct gift aid to two decimal places")]
        public void DonorViewGiftAid()
        {
            const int donation = 20;
            _mockValidation.Setup(x => x.ValidateDonation(donation)).Returns(20.00m);
            var res = _donorManagement.GiftAidAmount(donation);
            Assert.IsInstanceOf(typeof (decimal), res);
            _mockValidation.Verify(x => x.ValidateDonation(donation), Times.Once);
        }
    }
