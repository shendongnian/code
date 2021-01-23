    static T _MyList = new ReadOnlyList<T>();
        
        void Load(){
        T LocalList = _MyList.Copy();
        LocalList.Add(1);
        LocalList.Add(2);
        LocalList.Add(3);
        
        _MyList = LocalList.ReadOnly(); //Making it more clear
        Thread.MemoryBarrier();
    
        }
        
        DoStuff(){
        T LocalList = _MyList;
        
        foreach(t tmp in LocalList)
        }
