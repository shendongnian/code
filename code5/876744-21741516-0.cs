    public class Employee
    {
        // ...
        public int EducationLevelId { get; set; }
        public int ProfessionId { get; set; }
        [ForeignKey("EducationLevelId")]
        public virtual EducationLevel EducationLevel { get; set; }
        [ForeignKey("ProfessionId")]
        public virtual Profession Profession { get; set; }
    }
    public class EducationLevel
    {
        // ...
        public virtual ICollection<Employee> Employees { get; set; }
    }
    public class Profession
    {
        // ...
        public virtual ICollection<Employee> Employees { get; set; }
    }
