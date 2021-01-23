    class Person{
    public string FirstName{get;set;}
    public string LastName{get;set;}
    }
    
    Person person = new Person();
    person.FirstName = dataRow["fName"] ;
    person.LastName = dataRow["lName"] ;
