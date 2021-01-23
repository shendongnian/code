    void Main()
    {
        var students = new List<Student>()
        {
            new Student("Alphonso", "Zander"),
            new Student("Berta", "Zander"),
            new Student("Giacomo", "Zander"),
            new Student("Marc", "Lastly"),
            new Student("God", "Allmighty")
        };
        students.Sort(new StudentComparer());
        students.Dump();
    }
    class Student
    {
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName{get;set;}
        public string LastName{get;set;}
    }
    class StudentComparer:IComparer<Student>
    {
        public int Compare(Student a, Student b)
        {
            var lastName = a.LastName.CompareTo(b.LastName);
            if(lastName == 0)
                return a.FirstName.CompareTo(b.FirstName);
            return lastName;
        }	
    }
