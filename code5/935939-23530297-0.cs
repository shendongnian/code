    class Student
    {
        public int ID { get; set; } // ID is NOT unique
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Student> AddStudentsToList()
        {
            var students = source.Distinct().ToList();
           
            return students;
        }
        public override bool Equals(Student other)
        {
            var otherStudent = other as Student;
            if (otherStudent == null)
            {
                return false;
            }
            return otherStudent.ID == this.ID;
        }
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
