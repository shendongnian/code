    public class Person //I'm want to pass the parameter "Gender"
    {
        public string firstName;
        public string lastName;
        public int age;
        public Gender gender;  // recommend storing the enum instead of a string
    
        public Person (Gender gender)
        {
            this.gender = gender;
        }
    }
