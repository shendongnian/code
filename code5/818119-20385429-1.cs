    public class University
    {
        public virtual int Id { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Student> Students 
        {
            get { return Departments.SelectMany(d => d.Students); }
        }
    }
