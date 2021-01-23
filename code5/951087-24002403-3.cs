    public class MyCollection
    {
        public IList<SomeObject> Collection { get; private set; } // The setter would typically be private, and can be IList<T>!
        public MyCollection()
        {
            this.Collection = new List<SomeObject>();
            this.Collection.Add(new SomeObject
            {
                Collection = this.Collection
            });
        } 
    }
