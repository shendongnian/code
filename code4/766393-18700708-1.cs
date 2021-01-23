    [Fact]
    public void SomeTest() 
    {
        //arrange
        var mockRepository = new Mock<IPersonRepository>();
        var mockData = new List<Person>
            {
                new Person { Name = "Jim", Age = 47 }
            };
        mockRepository.Setup(x => x.GetAll).Returns(mockData);
        var bl = new SomeBusinessLogicClass(mockRepository.Object); 
    
        //act
        var result = bl.GetByFirstName("Jim");
    
        //assert
        //do some assertion
    }
