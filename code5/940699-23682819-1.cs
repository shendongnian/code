    public class Parent
    {
        public Child ChildProperty {get; set;}
        public Child ChildProperty2 {get; set;}
    }
    
    public class Child 
    {
        public string ParentPropertyName {get; protected set;}
    }
    var child = new Child();
    parent.ChildProperty = child;
    parent.ChildProperty2 = child;
