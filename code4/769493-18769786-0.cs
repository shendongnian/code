    [TestMethod]
    public void GetEmployeesReturnsAList()
    {
        List<Employee> result = MyClass.GetEmployees();
        Assert.IsNotNull(result);
    }
