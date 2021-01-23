    static T _MyList = new List<T>();
    
    void Load(){
    T LocalList = _MyList.Copy();
    LocalList.Add(1);
    LocalList.Add(2);
    LocalList.Add(3);
    
    _MyList = LocalList
    }
    
    DoStuff(){
    T LocalList = _MyList;
    
    foreach(t tmp in LocalList)
    }
