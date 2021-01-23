    public class EvaluationHead
    {
        ...
        // Employee
        public virtual Employee Employee   { get; set; }
        public virtual int      EmployeeID { get; set; }
    
        // Supervisor 
        public virtual Employee Supervisor   { get; set; }
        public virtual int      SupervisorID { get; set; }
    
        // Manager
        public virtual Employee Manager   { get; set; }
        public virtual int      ManagerID { get; set; }
    }
