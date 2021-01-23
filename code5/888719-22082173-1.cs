    public ObservableCollection(IEnumerable<T> collection)
    {
    	if (collection == null)
    	{
    		throw new ArgumentNullException("collection");
    	}
    	this.CopyFrom(collection);
    }
    private void CopyFrom(IEnumerable<T> collection)
    {
    	IList<T> items = base.Items;
    	if (collection != null && items != null)
    	{
    		using (IEnumerator<T> enumerator = collection.GetEnumerator())
    		{
    			while (enumerator.MoveNext())
    			{
    				items.Add(enumerator.Current);
    			}
    		}
    	}
    }
