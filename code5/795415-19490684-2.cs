    public class Person
    {
        public Person(string firstName, string lastName, Gender gender)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            if (gender == Gender.Male)
                this.FullName = "Mr. " + this.FirstName + " " + this.LastName;
            else
                this.FullName = "Mrs. " + this.FirstName + " " + this.LastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        // 'FullName' is a computed column:
        public string FullName { get; set; }
    }
