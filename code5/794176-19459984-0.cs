    [SetUp]
    public void Setup()
    {
        MockAppointmentRepository = new Mock<IRepository<Appointment>>();
        MockCustomerRepository = new Mock<IRepository<Customer>>();
        MockShiftRepository = new Mock<IRepository<Shift>>();
        MockEmployeeRepository = new Mock<IRepository<Employee>>();
        AppointmentService = new AppointmentService(MockCustomerRepository.Object, MockAppointmentRepository.Object, MockShiftRepository.Object, MockEmployeeRepository.Object);
        Customer = new Customer()
        {
            Address = "88 Taraview Road NE",
            City = "Calgary",
            Email = "charles.norris@outlook.com",
            FirstName = "Charles",
            LastName = "Norris",
            Id = 1,
            Phone = "587-888-8882",
            PostalCode = "X1X 1X1",
            Province = "AB"
        };
        Employee1 = new Employee()
        {
            Address = "12 Saddletowne Road NW",
            City = "Calgary",
            Email = "johnny.bravo@outlook.com",
            FirstName = "John",
            LastName = "Bravo",
            Id = 2,
            Phone = "403-999-2222",
            PostalCode = "X1X 1X1",
            Province = "AB"
        };
        Employee2 = new Employee()
        {
            Address = "12 Saddletowne Road NW",
            City = "Calgary",
            Email = "johnny.bravo@outlook.com",
            FirstName = "John",
            LastName = "Bravo",
            Id = 2,
            Phone = "403-999-2222",
            PostalCode = "X1X 1X1",
            Province = "AB"
        };
        Appointment = new Appointment()
        {
            Id = 1,
            Customer = Customer,
            CustomerId = Customer.Id,
            Employee = Employee1,
            EmployeeId = Employee1.Id,
            ScheduledTime = new DateTime(2013,10,15,18,30,00)
        };
    }
    [Test]
    public void IsCityAvailableShouldReturnAvailableWhenEmployeeInSameCityFound()
    {
    // ARRANGE
    MockCustomerRepository.Setup(x => x.Find(It.IsAny<int>())).Returns(Customer);
    MockEmployeeRepository.Setup(x => x.Get).Returns(new List<Employee> { Employee1, Employee2 }.AsQueryable());
    // ACT
    AppointmentService.IsCityAvailable(Appointment);
    // ASSERT
    MockCustomerRepository.Verify(x => x.Find(It.IsAny<int>()), Times.Once);
    MockEmployeeRepository.Verify(x => x.Get, Times.Once);
    }
