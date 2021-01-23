    class Person{
    public string FirstName{get;set;}
    public string LastName{get;set;}
    }
    
    Person person = new Person();
    person.FirstName = dataRow["FirstName"] ;
    person.LastName = dataRow["LastName"] ;
