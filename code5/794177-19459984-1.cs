    [Test]
    public void IsCityAvailableShouldReturnAvailableWhenEmployeeInSameCityFound()
    {
    // ARRANGE
    MockCustomerRepository.Setup(x => x.Find(It.IsAny<int>())).Returns(Customer);
    MockEmployeeRepository.Setup(x => x.Get).Returns(new List<Employee> { Employee1, Employee2 }.AsQueryable());
    // ACT
    var actual = AppointmentService.IsCityAvailable(Appointment);
    // ASSERT
    Assert.IsTrue(actual);
    }
