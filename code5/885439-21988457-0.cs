    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public class EqualityComparer : IEqualityComparer<Student>
        {
            public bool Equals(Student x, Student y)
            {
                return x.Name == y.Name;
            }
            public int GetHashCode(Student obj)
            {
                unchecked  // overflow is fine
                {
                    int hash = 17;
                    hash = hash * 23 + obj.Name.GetHashCode();
                    return hash;
                }
            }
        }
    }
