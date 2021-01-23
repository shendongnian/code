    [CollectionDataContract(ItemName = "Item")]
    public class ArrayOfItem : List<Item>
    {
    	public ArrayOfItem() { }
    	public ArrayOfItem(IEnumerable<Item> collection) : base(collection) { }
    	public ArrayOfItem(params Item[] collection) : base(collection) { }
    }
