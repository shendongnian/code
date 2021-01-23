    List<MyObject> Mylist;
    MyList = GetObjects(TheDate);
    Dictionary<DateTime> myDictionary = new Dictionary<DateTime>();
    myDictionary[TheDate] = MyList;
    Session["DateCollections"] = myDictionary;
    
    Sample for retrieving from session (should have null check to be sure it's there):
    
    Dictionary<DateTime> myDictionary  = (Dictionary<DateTime>) Session["DateCollections"];
