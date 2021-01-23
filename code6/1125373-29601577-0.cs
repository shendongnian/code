    public class PersonRequestModel
    {
    	public String FirstName { get; set; }
    	public String SecondName { get; set; }
    	
    	public static implicit operator Person(PersonRequestModel request) {
    		return new Person(request.FirstName, request.SecondName);
    	}
    }
    
    public class Person
    {
       private readonly String _firstName;
       private readonly String _secondName;
    
       public Person(String firstName, String secondName)
       {
           _firstName = firstName;
           _secondName = secondName;
       }
    
       public String FirstName
       {
           get { return _firstName; }
       }
    
       public String SecondName
       {
           get { return _secondName; }
       }
    }
 
