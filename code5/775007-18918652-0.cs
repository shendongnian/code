    private TestedService service;
    
    [SetUp]
    public void SetUp()
    {
        this.service = new TestedService(_mockedObject1.Object, _mockedObject2.Object, ...,
            _mockedObject7.Object);
    } 
    
    [TestMethod]
    public void Test1()
    {
        _mockedObject1.Setup(etc);
        _mockedObject2.Setup(etc);
    
        //Act and Assert
        this.service.Whatever(...);
    }
