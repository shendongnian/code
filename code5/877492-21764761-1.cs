    adapter.Fill(employees, "HumanResources.Employee");
    var items = new List<EmployeeDto>();
    foreach (var dr in employees)
    {
       var empDto = new EmployeeDto
       {
           FirstName = dr.Fields("FirstName"),
           LastName = dr.Fields("LastName"),
           // Additional fields go here...
       };
       items.Add(empDto);
    }
    alphaProxy.Clients.ReceiveDataSet(items); // Serializes the dto as json array by default.
                
