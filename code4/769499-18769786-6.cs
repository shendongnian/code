    [TestMethod]
    public void GetEmployeesReturns_The_OneEmployeeWhenThereIsOneEmployeeAvailable()
    {
        // Arrange
    
        Employee emp = new Employee();
    
        // Add code here to insert emp into the source of the list
        // This may be a mock.
    
        // Action
        List<Employee> result = MyClass.GetEmployees();
        Assert.AreEqual(1, result.Count);
        Assert.AreSame(emp, result[0]);
    }
