    public class Base
    {
        public string name { get; set; }
        public string parent { get; set; }
        public string status { get; set; }
    }
    public class Abc : Base { }
    public class Def : Base { }
    public class Objects
    {
        public Abc abc { get; set; }
        public Def def { get; set; }
    }
    public class ObjectContainer
    {
        public int count { get; set; }
        public Objects objects { get; set; }
    }
    public class RootObject
    {
        public ObjectContainer objectContainer { get; set; }
    }
