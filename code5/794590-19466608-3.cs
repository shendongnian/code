    abstract class People
    {
        public string FirstName;
        public string LastName;
    
        public People(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
    
    sealed class Student : People
    {
        public int StudentId;
    
        public Student(string firstName, string lastName, int studendId)
            : base(firstName, lastName) //Calling the base class constructor
        {
            StudentId = studendId;
        }
    }
