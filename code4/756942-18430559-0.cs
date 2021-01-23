    public class Person
    {
        public int Age { get; set; } // I would use properties and public properties are 
                                     // starting with a great letter
        public double Heigth { get; set; }
        public double Weigth { get; set; }
        public string Nationality { get; set; }
        public int ShoeSize { get; set; }
    }
    public class BankAccount
    {
        private Person _person; // private field for the person object
        public int AccountNumber { get; private set; } // public propertie for the account 
                                                       // number with a private setter 
                                                       // because normally you want to read
                                                       // that from the outside but not set
                                                       // from the outside
        public string FirstName
        {
            get { return _person.FirstName; }
        }
        public string LastName;
        {
            get { return _person.LastName; }
        }
        public string BankName { get; set; }
        public Bank(Person person, int accountNumber)
        {
            AccountNumber = accountNumber;
            _person = person;
        }
    }
