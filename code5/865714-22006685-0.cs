    timeActivity.NameOf = TimeActivityTypeEnum.Employee;
    timeActivity.NameOfSpecified = true;
    timeActivity.ItemElementName = ItemChoiceType5.EmployeeRef;    
    timeActivity.AnyIntuitObject= new ReferenceType()
    {
        name = resultEmployee.DisplayName,
        Value = resultEmployee.Id,
    };
