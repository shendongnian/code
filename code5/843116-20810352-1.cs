    public class MyItem
    {
        public NestedItem NestedItem { get; set; }
        public int Number { get; set; }
    	public String NestedItemName { get { return NestedItem.Name; } }
    }
