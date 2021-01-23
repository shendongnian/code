    class OrderProcessor{
     private IService service, IStorage storage;
     public OrderProcessor(IService service, IStorage storage){ // bla bla}
    
     public ProcessOrder(Order o){
       // do something
    
      // use the service
      var price = service.GetPrice(..);
    
    
      // store the result
      storage.StoreOrder(order);
     }
    }
    
    // test. Define mocks
    var mockStorage = new Mock<IStorage>();
    var mockService = new Mock<IService>();
    // Setup test behaviour
    mockStorage.Setup(m => m.GetPrice("X10").Returns(11);
    mockStorage.Setup(m => m.GetPrice("X11").Returns(99);
    ...
    var target = new OrderProcessor(mockService.Object, mockStorage.Object);
    
    // ...
    target.ProcessOrder(o);
    
    // Verify the storing was called
    mockStorage.Verify(m => m.StoreOrder(o), Times.Once());
    
    // Verify the service was called X times
    mockService .Verify(m => m.GetPrice(x), Times.Exactly(order.Items.Count));
