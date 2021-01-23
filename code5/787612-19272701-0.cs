    class SchoolClass
    {
        protected Dictionary<uint, Student> _Students = new Dictionary<uint, Student>();
        public IEnumerable<Student> Students
        {
            get { return _Students.Values.AsEnumerable(); }
        }
        public SchoolClass(List<Student> students)
        {
            if (students == null) throw new ArgumentNullException("Students list can not be null!");
            foreach (var student in students)
                AddStudent(student);
        }
        public void AddStudent(Student student)
        {
            if (_Students.ContainsKey(student.Number))
                throw new ArgumentException("There are students in the list with the same class number!");
            _Students.Add(student.Number, student);
        }
    }
