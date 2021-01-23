    private bool aValue;
    public void SetIt() 
    { 
        if (aValue != (aValue = true)) 
          onSet(); // do something on change to true
    }
    public void UnsetIt() 
    { 
        if (aValue != (aValue = false))
          onUnset();  // do something on change to false
    }
    
