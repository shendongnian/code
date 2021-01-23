     public class EmployeeTimesheetDetails
    {
        public int EMP_ID { get; set; }
        public string EMP_COMP_ID { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string COMPANY_NAME { get; set; }
        public string PrimaryEmail { get; set; }
        public DateTime SDate { get; set; }
        public DateTime EDate { get; set; }
        public string EMP_STATUS { get; set; }
    }
    public class ContractorsTimesheetDetails
    {
        public int CONTR_ID { get; set; }
        public string CONTRACTOR_NAME { get; set; }
        public string COMPANY_NAME { get; set; }
        public DateTime SDate { get; set; }
        public DateTime EDate { get; set; }
        public string CLIENT_NAME { get; set; }
        public string PrimaryEmail { get; set; }
    } 
