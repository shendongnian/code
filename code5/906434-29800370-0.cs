    public class SampleModel
    {
        public List<ItemModel> Items { get; set; }
        public SampleModel()
        {
            Items = new List<ItemModel>();
        }
    }
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
