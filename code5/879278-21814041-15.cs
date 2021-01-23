    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public string Email { get; set; }
        public Person(string firstName, string lastName, int id, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            ID = id;
            Email = email;
        }
    }
