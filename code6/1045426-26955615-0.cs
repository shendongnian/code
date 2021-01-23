    private Object myLock = new Object();
    
    public MyClass ReadFromSharedArray()
    {
    lock(myLock)
    {
    //do whatever here
    }
    
    }
    
    public void WriteToSharedArray(MyClass data)
    {
    lock(myLock)
    {
    //Do whatever here
    }
    
    }
