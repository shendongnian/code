    public abstract class BaseClass
    {
    
    }
    
    public class Child1:BaseClass
    {
    
    }
    
    public class Child2:BaseClass
    {
    
    }
    
    public class SeriliazerTest
    {
            // You have to define them here, otherwise they will not be found
            [XmlArrayItem(Type = typeof(Child1), ElementName = "Child1")]
            [XmlArrayItem(Type = typeof(Child2), ElementName = "Child2")] 
            public BaseClass[] Child {get;set;}
     }
