    using System.ComponentModel.DataAnnotations;
    public class Employees
    {
        [Required, RangeAttribute(0, 99)]
        public int EmpID { get; set; }
        [Required, Length(30), RegularExpression("/^[A-z]+$/")]
        public string FirstName { get; set; }
        [Required, Length(30), RegularExpression("/^[A-z]+$/")]
        public string LastName { get; set; }
        [Required]
        public decimal Salary { get; set; }
    }
