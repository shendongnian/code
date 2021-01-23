    public class Item
    {
    	public int Value { get; set; }
    	public Item SubItem { get; set; }
    	public Item NextItem { get; set; }
    
    	public Item(int value, Item subItem)
    	{
    		Value = value;
    		SubItem = subItem;
    	}
    
    	public Item CreatePreviousItem()
    	{
    		if (SubItem == null)
    		{
    			return Value == 1 ? null : new Item(Value - 1, null);
    		}
    
    		return new Item(Value, SubItem.CreatePreviousItem());
    	}
    
    	public bool IsItemMissingPrior(Item item)
    	{
    		if (item == null)
    		{
    			return false;
    		}
    
    		return 
    			item.Value - Value > 1 
    			|| (SubItem == null && item.SubItem != null && item.SubItem.Value > 1) //edge case
    			|| (SubItem != null && SubItem.IsItemMissingPrior(item.SubItem));
    	}
    
    	public override string ToString()
    	{
    		return Value + (SubItem != null ? "." + SubItem : "");
    	}
    }
