        public class Student
        {
            private readonly Dictionary<string, object> _customProperties = new Dictionary<string, object>();
            public Dictionary<string, object> CustomProperties { get { return _customProperties; } }
        }
