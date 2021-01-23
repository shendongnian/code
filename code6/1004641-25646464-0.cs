    if(employee!=null){
        if(employee.PayHistories.Any()){
            PayHistories = (from ph in employee.PayHistories
                            select new EmployeePayHistoryListDTO
                            {
                                Id = ph.BusinessEntityId,
                                RateChangeDate = ph.RateChangeDate,
                                Rate = ph.Rate,
                                PayFrequency = ph.PayFrequency,
                                JobTitle = ph.Employee.JobTitle,
                                Gendre = ph.Employee.Gender
                            }).ToList();
        }
    }
