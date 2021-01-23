     public class Project
    {
        [Key]
        public int Project_Id { get; set; }
        public string Project_Name { get; set; }
        public string Project_Detail { get; set; }
        public string Project_Status { get; set; }
        public int Employee_Id { get; set; }
    }
    
     public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Detail { get; set; }   
    }
