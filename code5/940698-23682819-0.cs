    public class Parent
    {
        public Child ChildPropertyName {get; set;}
        public Child ChildPropertyName2 {get; set;}
    }
    
    public class Child 
    {
        public string ParentPropertyName {get; protected set;}
    }
    var child = new Child();
    parent.ChildPropertyName = child;
    parent.ChildPropertyName2 = child;
