    public void RollinAlong()
    {
       int i = 0;
       SomeFunc(ref i);
       // with    the ref keyword i will be 1 here
       // without the ref keyword i will be 0 here
    }
    
    public void SomeFunc(ref int i)
    {
       i = 1;
    }
