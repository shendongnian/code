     public void GetEmployeeContractorsTimesheetNotEntered(int COMP_ID, string COMPANY_NAME, CompanyListModel model)
      {
         // your stuff
         CompanyModel conpanyModel = new CompanyModel();
         conpanyModel.EmployeesNotEnteredTimesheetList  = employeesNotEnteredTimesheetList.GroupBy(m => m.EMP_ID).Select(m => m.First()).ToList();
        
         conpanyModel.ContractorsNotEnteredTimesheetList = contractorsNotEnteredTimesheetList.GroupBy(m => m.EMP_ID).Select(m => m.First()).ToList(); 
    
         model.CompanyList.add(companyModel);
         // your stuff
    }
