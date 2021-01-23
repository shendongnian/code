    public class Employee
    {
        [Required]
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeRollNum { get; set; }
        public EmployeeAddress EmployeeAddr { get; set; }
        public List<EmployeeAddress> AllEmployeeAddr { get; set; }
    }
    public class EmployeeAddress
    {
        //[Required]
        public string EmployeeAddressId { get; set; }
        public string EmployeeAddressName { get; set; }
        public List<int> AllNum { get; set; }
    }
