    List<ItemList> myList = new List<ItemList> { 
    	new ItemList() { Day="S", ID=10 },
    	new ItemList() { Day="M", ID=20 },
    	new ItemList() { Day="T", ID=30 },
    };
    
    foreach(ItemList key in myList)
    {
    	ItemList result = myList.FindLast(x=>x.ID<key.ID);
    	if(result!=null)
    	{
    		MessageBox.Show("Prev ID: " + result.ID.ToString());
    	}
    }
