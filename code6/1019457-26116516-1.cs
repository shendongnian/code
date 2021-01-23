    class YourClass
    {
        private DAL customerDal;
        public YourClass(DAL theDal)
        {
            customerDal = theDal;
        }
    
        public List<CustomerObject> FetchCustomersByName(CustomerObject obj)
        {
           // don't create the DAL here...
           //Maybe other operations
           List<CustomerObject> list = customerDal.FetchByName(obj.Name);
           //Maybe other operations over list
           return list;
         }
    }
    [Test]
    public void TestMethodHere()
    {
        // Arrange
        var dalMock = Mock.Of<DAL>();
        // setup your mock DAL layer here... need to provide data for the FetchByName method
        var sut = new YourClass(dalMock);
    
        // Act
        var actualResult = sut.FetchCustomersByName(new CustomerObject());
    
        // Assert
        // Your assert here...
    }
