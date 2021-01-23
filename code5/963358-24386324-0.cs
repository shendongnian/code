    public class Student
    {
        public int Id { get;  set; }
        public string Name { get;set; }
        public override bool Equals(object obj)
        {
            Student s2 = obj as Student;
            if (s2 == null) return false;
            return Id == s2.Id && Name == s2.Name;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id;
                hash = hash * 23 + Name.GetHashCode();
                return hash;
            }
        }
    }
