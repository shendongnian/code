    class Student : User
    {
        private readonly int _id;
        public Student(string name, int basicId, int studentId)
            : base(name, basicId)
        {
            _id = studentId;
        }
        public new int GetId() { return _id; }
    }
