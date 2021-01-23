    public class MyObject()
    {
        public string SomeData { get; set; }
        public int SomeOtherData { get; set; }
    }
    public class MyOtherObject()
    {
        public Guid ID { get; set; }
        public object Foo { get; set; }
    }
    public class Main()
    {
        private List<MyObject> objects = new List<MyObject>();
        private List<MyOtherObject> moreObjects = new List<MyOtherObject>();
        public CompositeCollection TheCollection { get; private set; }
        
        public Main()
        {
            //mock adding data to the list
            objects.Add( ... );
            moreObjects.Add ( ... );
            //Build the composite collection
            TheCollection = new CompositeCollection
            {
                new CollectionContainer {Collection = objects},
                new CollectionContainer {Collection = moreObjects}                  
            };
        }
    }
