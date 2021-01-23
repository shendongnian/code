    public class Parent {
        public Child { get; set; }
        public string ChildName { get => Child.Name; }
    }
    
    public class Child {
        public string Name { get; set; }
    }
