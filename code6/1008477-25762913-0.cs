    public class Parent
    {
        public bool IAmAParent { get; set; }
    }
    public class Child : List<Parent>
    { }
    var c = new Child();
    c[0].IAmAParent = true;
