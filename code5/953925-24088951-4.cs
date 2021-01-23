    //Suggested to just use volatile instead of memorybarrier
        static volatile T _MyList = new ReadOnlyList<T>();
        
        void Load(){
        T LocalList = _MyList.Copy();
        LocalList.Add(1);
        LocalList.Add(2);
        LocalList.Add(3);
        
        _MyList = LocalList.ReadOnly(); //Making it more clear
    
        }
        
        DoStuff(){
        T LocalList = _MyList;
        
        foreach(t tmp in LocalList)
        }
