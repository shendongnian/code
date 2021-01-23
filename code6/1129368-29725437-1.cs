    class Student : User
    {
        private int _id;
        public Student(string name, int basicId, int studentId)
            : base(name, basicId)
        {
            _id = studentId;
        }
    }
