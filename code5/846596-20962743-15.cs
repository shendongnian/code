    public class MyDataObjects
    {
        public MyDataObjects()
        {
            this.CollectionProperty = new Collection<string> {"Item 1", "Item 2", "Item 3"};            
            this.StringProperty = "Hi!";
        }
        public string StringProperty { get; set; }
        [Editor(typeof(ReadOnlyCollectionEditor), typeof(ReadOnlyCollectionEditor))]
        public ICollection<string> CollectionProperty { get; private set; } 
    }   
