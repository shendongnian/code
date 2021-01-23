    //Declare itemsource    
    ObservableCollection<string> list;
    
    //Bind to longlistselector dynamically somewhere in code
    longlistselector.ItemSource = list;
    
    //Add items into your source
    list.Add("test1");
    list.Add("test2");
    list.Add("test3");
    
    //Delete items
    list.RemoveAt(input item index here);
    
    //OR
    
    list.Remove(item); //if you're able to retrieve item ref;
