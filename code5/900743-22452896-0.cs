    [TestMethod]
    public void GetEmployeeById_Id_Employee()
    {
       Employee employee = mockManager.MockObject<Employee>().Object;
       employee.DateOfBirth = new DateTime(1970, 1, 1, 0, 0, 0);
    
       using (RecordExpectations recorder = new RecordExpectations())
       {
    	 var dataLayer = new DataLayer();
    	 recorder.ExpectAndReturn(dataLayer.GetEmployeeById(1), employee);
       }
    
       var company = new Company();
       Employee result = company.GetEmployeeById(1);
       Assert.AreEqual(result.DateOfBirth, employee.DateOfBirth);
    }
