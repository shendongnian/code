    string _FirsName;   
    string _LastName;   
    public string FullName 
    { 
       get 
       { 
          return _FirsName + _LastName;
       }
       set; 
    } 
    public string ReverseName 
    { 
       get 
       { 
          return _LastName + ", " + _FirsName;
       }
       set; 
    }
