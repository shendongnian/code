    class UpdateRequest
    {
       public int EmployeeId { get; set; }
       public Maybe<string> EmployeeName { get; set; }
       public Maybe<decimal> Salary { get; set; }
    }
