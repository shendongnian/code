    public class NameValueCollectionWrapper
    {
        public NameValueCollectionWrapper()
        {
            this.Collection = new NameValueCollection();
        }
        public NameValueCollection Collection { get; private set; }
    }
