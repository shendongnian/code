    [Test]
    public void ShouldReturnExistingCustomer()
    {
        // Arrange
        int id = 42; // or random numer
        var dto = // data which ICustomer should return
        Mock<ICustomer> customerMock = new Mock<ICustomer>();
        customerMock.Setup(c => c.GetById(id)).Returns(dto)
        var controller = new MyController(customer.Object);
        // Act
        var result = controller.GetCustomer(id);
        // Assert
        customerMock.VerifyAll();
        Assert.IsNotNull(result); // etc
    }
