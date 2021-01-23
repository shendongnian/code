    [TestClass]
    public class FeatureServiceTests {
    
      // mock of Mediator to handle request/responses
      private Mock<IMediator> _mediator;
    
      // subject under test
      private FeatureService _sut;
    
      [TestInitialize]
      public void Setup() {
    
        // set up Mediator mock
        _mediator = new Mock<IMediator>(MockBehavior.Strict);
    
        // inject mock as dependency
        _sut = new FeatureService(_mediator.Object);
      }
    
      [TestCleanup]
      public void Teardown() {
    
        // ensure we have called or expected all calls to Mediator
        _mediator.VerifyAll();
      }
    
      [TestMethod]
      public void ComplexBusinessLogic_Does_What_I_Expect() {
        var dbObjects = new List<DbObject>() {
          // set up any test objects
          new DbObject() { }
        };
    
        // arrange
        // setup Mediator to return our fake objects when it receives a message to perform our query
        // in practice, I find it better to create an extension method that encapsulates this setup here
        _mediator.Setup(x => x.Send(It.IsAny<GetRelevantDbObjectsQuery>(), default(CancellationToken)).ReturnsAsync(dbObjects.ToArray()).Callback(
        (GetRelevantDbObjectsQuery message, CancellationToken token) => {
           // using Moq Callback functionality, you can make assertions
           // on expected request being passed in
           Assert.IsNotNull(message);
        });
    
        // act
        _sut.ComplexBusinessLogic();
    
        // assertions
      }
    
    }
