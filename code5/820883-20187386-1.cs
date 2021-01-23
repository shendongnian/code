    var result = myEmployeeRecord.Save();  // result is of type IResult<Employee>
    
    if (result.IsSuccess) { 
        Display(result.Message);
    } else {
        Display("Error: " + result.Data.Name + " could not be saved");
        // result.Data is of type "Employee"
    }
    
