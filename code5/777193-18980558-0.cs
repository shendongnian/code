    public class MyViewModel
    {
        public DataItemCollectionTypeName ItemCollection { get; set; }
        public void DeleteItem(DataItemTypeName item)
        {
            ItemCollection.Remove(item);
        }
    }
