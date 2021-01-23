    public class Base
    {
        public string name { get; set; }
        public string parent { get; set; }
        public string status { get; set; }
    }
    public class Objects
    {
        public List<Base> bases { get; set; }
        public Objects()
        {
            bases = new List<Base>();
        }
    }
    public class ObjectContainer
    {
        public int count { get; set; }
        public Objects objects { get; set; }
        public ObjectContainer()
        {
            objects = new Objects();
        }
    }
    public class RootObject
    {
        public ObjectContainer objectContainer { get; set; }
        public RootObject()
        {
            objectContainer = new ObjectContainer();
        }
    }
