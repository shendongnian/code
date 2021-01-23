    public class Person
    {
        public string FirstName { get; protected set; }
        public string SetFirstName(string value)
        {
           _firstName = value;
           // DO STUFF;
        }
    }
