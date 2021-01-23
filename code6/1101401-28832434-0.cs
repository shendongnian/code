    private class Student
    {
        public String FirstName { get; set; }
        public String Surname { get; set; }
        public Student(String firstName, String surname)
        {
            FirstName = firstName;
            Surname = surname;
        }
        public override string ToString()
        {
            return FirstName + " " + Surname;
        }
    }
