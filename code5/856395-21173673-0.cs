    public class MyClass
    {
        private readonly IRepository _repository;
        
        public MyClass( IRepository repository )
        {
            _repository = repository;
        }
        public void DoSomethingThatMightThrow()
        {
            // some logic that you want to test
            
            // this might throw
            var obj = _repository.Delete( 123 );
            // some logic that you want to test
        }
    }
    [TestMethod]
    public void ATest()
    {
        // uses Moq framework, but any mocking framework should do this
        var repository = new Mock<IRepository>();
        repository.Setup( o => o.Delete( It.IsAny<int>() ) ).Throws( new DataException() );
        var obj = new MyClass( repository );
        obj.DoSomethingThatMightThrow();
    }
