    public void Test(Type1 param1)
    {
       this.Test(param1, null);
    }
    
    public void Test(Type2 param2)
    {
       this.Test(null, param2);
    }
    
    
    private void Test(Type1 param1, Type2 param2)
    {
       //...
    }
