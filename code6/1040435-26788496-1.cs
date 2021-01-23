    interface IParent
    {
       string Name {get; set;}
       string Age {get; set;}
    }
    
    class Child
    {
       Parent Parent {get; set;}
    }
    
    class Parent
    {
       IEnumerable<Child> Children {get; set;}
    }
    ...
    class Parent : IPerson
    class Child : IPerson
