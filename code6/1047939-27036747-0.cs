    public class MyAttribute : Attribute
    {
        
    }
    public class SomeClass {
    [MyAttribute]
    public List<Object> PropertyOne { get; set; }
    public List<Object> PropertyTwo { get; set; }
    
    public SomeClass() {
    PropertyOne = new List<Object>();
    PropertyTwo = new List<Object>();
    }
    }
