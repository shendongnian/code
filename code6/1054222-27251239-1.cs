    class Person
    {
        public Person()
        {
          PhoneNbrList = new List<string>()
        }
        public List<string> PhoneNbrList;
        public List<string> GetListOfListOfP() { return PhoneNbrList; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    List<Person> objPerson = new List<Person>();
    
    Person obj1 = new Person();
    //Initialise obj1 here
    objPerson.Add(obj1);
    
    Person obj2 = new Person();
    //Initialise obj2 here
    objPerson.Add(obj2);
    
    ......// Add all the objects to list in same manner
    
    
    // Query through list
    
    foreach(var item in objPerson)
    {
       // Access each of the items of list here
       foreach(var phoneNumbers in item.PhoneNbrList)
       {
          //Access your each phone number here
       }
    }
