    [Serializable]
    public class CategoricalDataItemCollection : ObservableCollection<CategoricalDataItem>
    {
    	public string Descriptor { get; set; }
    
    	public CategoricalDataItemCollection()
    	{
    		this.CollectionChanged += MyCollectionChanged;
    	}
    
    	void MyCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
    	{
    		// There are other actions to handle. This is purely an example.
    		if (args.OldItems != null)
    		{
    			foreach (var oldItem in args.OldItems.Cast<CategoricalDataItem>())
    			{
    				if (args.Action == NotifyCollectionChangedAction.Remove)
    					oldItem.SimpleSubData.CollectionChanged -= InvokeCollectionChanged;
    			}
    		}
    
    		if (args.NewItems != null)
    		{
    			foreach (var newItem in args.NewItems.Cast<CategoricalDataItem>())
    			{
    				if (args.Action == NotifyCollectionChangedAction.Add)
    					newItem.SimpleSubData.CollectionChanged += InvokeCollectionChanged;
    			}
    		}
    	}
    
    	void InvokeCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
    	{
    		// This is the tricky part. Nothing actually changed in our collection, but we
    		// have to signify that something did.
    		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    	}
    }
    
    public class TestClass
    {
    	public void TestNotify()
    	{
    		var parent = new CategoricalDataItemCollection();
    		parent.CollectionChanged += (sender, args) => Debug.Print("Parent Collection Changed");
    
    		var child = new CategoricalDataItem {SimpleSubData = new CategoricalDataItemCollection()};
    		child.SimpleSubData.CollectionChanged += (sender, args) => Debug.Print("Child Collection Changed");
    
    		var grandChild = new CategoricalDataItem { SimpleSubData = new CategoricalDataItemCollection()};
    		grandChild.SimpleSubData.CollectionChanged += (sender, args) => Debug.Print("Grand Child Collection Changed");
    
    		//Should only output "Parent"
    		parent.Add(child);
    
    		//Should only output "Child" and then "Parent"
    		child.SimpleSubData.Add(grandChild);
    		
    		//Should now output "Grand Child" and then "Child" and then "Parent" messages.
    		grandChild.SimpleSubData.Add(new CategoricalDataItem(){SimpleSubData = new CategoricalDataItemCollection()});
    	}
    }
