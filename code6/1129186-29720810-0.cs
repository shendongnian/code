    public class ItemCollection
    {
    	private ItemEnumerator<T> GetItemsOfTypeEnumerator<T>() {}
    
    	public ItemEnumeratorWrapper<T> ItemsOfType<T>()
    	{
    		return new ItemEnumeratorWrapper<T>(this);
    	}
    
    	public ItemEnumerator<Item> GetEmumerator() {}
    	
    	public struct ItemEnumeratorWrapper<T> where T : Item
    	{
    		private ItemCollection _collection;
    		
    		public ItemEnumeratorWrapper<T>(ItemCollection collection)
    		{
    			_collection = collection;
    		}
    		
    		public ItemEnumerator<T> GetEnumerator()
    		{
    			return _collection.GetItemsOfTypeEnumerator<T>();
    		}
    	}
    }
