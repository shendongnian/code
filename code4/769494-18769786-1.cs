    [TestMethod]
    public void GetEmployeesReturnsOneEmployeeWhenThereIsOneEmployeeAvailable()
    {
        List<Employee> result = MyClass.GetEmployees();
        Assert.AreEqual(1, result.Count);
    }
