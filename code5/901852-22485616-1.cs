    class Students : IEnumerable<Student>
    {
        private readonly List<Student> students;
        public Students(IEnumerable<Student> students)
        {
            this.students = students.ToList();
        }
        public IEnumerator<Student> GetEnumerator()
        {
            return students.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return students.GetEnumerator();
        }
    }
