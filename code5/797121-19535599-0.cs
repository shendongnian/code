        class Student
        {
            //ideally properties
            public int id
            public string name;
            public int age;
            public int marks;
            public Student friend; 
            static readonly Dictionary<int, Student> students = new Dictionary<int, Student>();
            
            //a static factory method with whatever definition, but int id is a must
            public static Student Create(int id, string name, int age, int marks)
            {
                Student student;
                return students.TryGetValue(id, out student) 
                     ? student 
                     : new Student(id, name, age, marks)     
            }
            //private constructor, with whatever definition.
            private Student(int id, string name, int age, int marks)
            {
            
            }
        }
    Overriding `Equals` and `GetHashCode` gives it better meaning.
