    public class Parent
    {
        public bool IAmAParent { get; set; }
    }
    public class Child : Parent
    { }
    var c = new List<Child>();
    c[0].IAmAParent = true;
