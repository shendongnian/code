    public class CompanyListModel
    {
         public List<CompanyModel> CompanyList { get; set; };
    }
    public class CompanyModel 
    {
            public List<TimesheetModel > EmployeesNotEnteredTimesheetList { get; set; };
    
            public List<TimesheetModel > ContractorsNotEnteredTimesheetList { get; set; };
    }
