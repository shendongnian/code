    private List<T> selectedItem;
    public List<T> SelectedItem
    {
    	get { return selectedItem; }
    	set
    	{
    		if (value != selectedItem)
    		{
    			selectedItem = value;
    			
    			ItemsListView1 = new ObservableCollection<T>(selectedItem.Where(x=>x.Prop>0));
    			ItemsListView2 = new ObservableCollection<T>(selectedItem.Where(x=>x.Prop<0));
    			NotifyOfPropertyChange(() => SelectedItem);			
    		}
    	}
    }
    
    private ObservableCollection<T> itemsListView1;
    public ObservableCollection<T> ItemsListView1
    {
    	get { return itemsListView1; }
    	set
    	{
    		if (value != itemsListView1)
    		{
    			itemsListView1 = value;
    			NotifyOfPropertyChange(() => ItemsListView1);
    		}
    	}
    }
    
    private ObservableCollection<T> itemsListView2;
    public ObservableCollection<T> ItemsListView2
    {
    	get { return itemsListView2; }
    	set
    	{
    		if (value != itemsListView2)
    		{
    			itemsListView2 = value;
    			NotifyOfPropertyChange(() => ItemsListView2);
    		}
    	}
    }
