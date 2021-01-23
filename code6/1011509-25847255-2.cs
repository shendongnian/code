     public void GetEmployeeContractorsTimesheetNotEntered(int COMP_ID, string COMPANY_NAME, NewModel model)
      {
         // your stuff
         model.EmployeesNotEnteredTimesheetList  = employeesNotEnteredTimesheetList.GroupBy(m => m.EMP_ID).Select(m => m.First()).ToList();
        
         model.ContractorsNotEnteredTimesheetList = contractorsNotEnteredTimesheetList.GroupBy(m => m.EMP_ID).Select(m => m.First()).ToList(); 
    
         // your stuff
    }
