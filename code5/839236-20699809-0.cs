    public class RoleAndEmployee
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    
        public static Employee EmployeeFactory(IDataRecord record)
        {
            return new RoleAndEmployee
            {
                EmployeeID = (int)record[0],
                EmployeeName = (string)record[1],
                RoleID = (int)record[2],
                RoleName = (string)record[3]
            };
        }
    }
