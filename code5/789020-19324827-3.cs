    [Test]
    public void ReturnView()
    {
       // ACT
       var controller = new CustomerController(CustomerRepository.Object);
       var result = controller.Create(Customer);
       // ASSERT
       Assert.AreEqual("Create", ((ViewResult)result).ViewName);
    }
