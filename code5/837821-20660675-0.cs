    public class ReadOnlyCollectionHolder
    {
        private List<string> _innerCollection=new List<string>();
        public ReadOnlyCollectionHolder()
        {
            ItemList = new ReadOnlyCollection<String> (_innerCollection);
        }
        public readonly ReadOnlyCollection<String> ItemList {get;private set;}
    }
