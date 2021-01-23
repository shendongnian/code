    public interface IPaymentService
    {
        int Pay(int clientId);
    }    
    
    public interface IStore
    {
        int ID { get; }
        // Returns the payment ID of the payment you just created
        // You would expand this method to include more parameters as
        // necessary
        int CreatePayment();
    }
    
    public class PaymentService : IPaymentService
    {
        private readonly IStore _store;
        public PaymentService(IStore store)
        {
            _store = store;
        }
        // Insert payment and return PaymentID
        public int Pay(int clientId)
        {
            //int storeId = StaticContext.Store.CurrentStoreId;
            // Static is bad for testing and this also means you're hiding
            // Payment Service's dependencies. Inject a store into the constructor
            var storeId = _store.ID;
        }
    
    }
    
    public class Payment_Tests
    {
        [Test]
        public void When_Paying_Should_Return_PaymentId
        {
            // Arrange
            var store = new Mock<IStore>();
            var expectedId = 42;
            store.Setup(x => x.CreatePayment()).Returns(expectedId);
            var service = new PaymentService(store);
    
            // Act
            var result = paymentService.Pay(123);
    
            // Asserts and rest of the test goes here
            Assert.Equal(expectedId, result);
        }
    
    }
