    int Count = 0;
    Collection Coll = new Collection();
    YourBindedClass _YourBindedClass = default(YourBindedClass);
    Count = GridControl.VisibleRowCount;
    
    for (i = 0; i <= Count - 1; i++) {
    	    
    	_YourBindedClass = GridControl.GetRow(i);
    	if (_YourBindedClass.Selected == true) {
    		Coll.Add(_YourBindedClass.MyName);
    		//Get the "MyName" values here and add to collection
    	}
    }
