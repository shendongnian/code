    public void createRpt(string reportNum, Object selectedItems)
    {
        //Add debugging code
        var itemCollection = selectedItems as ItemCollection;
        if(itemCollection == null)
        {
            Debug.WriteLine("selectedItems can not be casted to ItemCollection, or not initialized.");
            return;
        }
        if(itemCollection.Count <= 0)
        {
            Debug.WriteLine("Collection is empty");
            return;
        }
        //Find the information held within selectedItems and do something with it.
        foreach(var item in itemCollection) 
        {
          //Do something with items
        }
    }
