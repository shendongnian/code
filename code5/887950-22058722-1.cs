    public sealed class Student {
        private readonly DateTime _lastAttended;
        public DateTime LastAttended { get { return _lastAttended; } }
        public Student(DateTime lastAttended)
        {    
            _lastAttended = lastAttended;
        }
    }
