    [Test]
    public void CanCreateCustomer()
    {
        // ACT
        var controller = new CustomerController(CustomerRepository.Object);
        controller.Create(Customer);
        // VERIFY
        CustomerRepository.Verify(c => c.Add(It.Is.Any<Customer>(),Times.Once()));
    }
