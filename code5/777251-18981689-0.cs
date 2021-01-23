    public class Record
    {
        [JsonProperty("Employee")]
        public Employee Employee { get; set; }
    }
    
    public class Employee
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        
        [JsonProperty("EmployeeName")]
        public string EmployeeName { get; set; }
    }
    var record = JsonConvert.DeserializeObject<Record>(json);
    
    var employeeId = record.Employee.Id;
    var employeeName = record.Employee.EmployeeName;
