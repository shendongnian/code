    public class MyTestFixture
    {    
        public Mock<MyManager> ManagerMock;
    
        public TestFixture() // runs once
        {
            ManagerMock.Setup(...);
        }
    }
    
    public MyTestClass : IUseFixture<MyTestFixture>
    {
        private MyTestFixture fixture;
    
        public MyTestClass()
        {
             // ctor runs for each [Fact]
        }
    
        public void SetFixture(MyTestFixture fixture)
        {
            this.fixture = fixture;
        }
    
        [Fact]
        public void MyTest
        {
             // use Mock
             fixture.ManagerMock.DoSomething()
        }
    }
 
