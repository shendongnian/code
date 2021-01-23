    public class DataObjectBase
    {
       //.. Whatever members you want to have in the base class for entities.
    }
    public class Person: DataObjectBase
    {
        public string LastName {get;set;}
    }
    
    public class Product: DataObjectBase
    {
        public string ProductName {get;set;}
    }
