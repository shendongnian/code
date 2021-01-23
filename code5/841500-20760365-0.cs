    private int _myAge {get; set;}
    
    public int MyAge
    {
       get
       {      
          if(_myAge == null)
          {
             _myAge == GetMyAge();
          }
    
          return _myAge; 
  
       }
    
    }
