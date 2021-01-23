    var filePath = @"C:\Users\grahamo\Documents\Visual Studio 2013\Projects\WebApplication1\WebApplication1\bin\path.json";
    // Read existing json data
    var jsonData = System.IO.File.ReadAllText(filePath);
    // De-serialize to object or create new list
    var employeeList = JsonConvert.DeserializeObject<List<EmployeeDetail>>(jsonData) 
                          ?? new List<EmployeeDetail>();
    
    // Add any new employees
    employeeList.Add(new EmployeeDetail()
    {
        Name = "Test Person 1"
    });
    employeeList.Add(new EmployeeDetail()
    {
        Name = "Test Person 2"
    });
    
    // Update json data string
    jsonData = JsonConvert.SerializeObject(employeeList);
    System.IO.File.WriteAllText(filePath, jsonData);
