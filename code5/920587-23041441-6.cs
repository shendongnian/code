    public void RollinAlong()
    {
       int i = 0;
       SomeFunc(ref i);
       // i will be 1 without the ref keyword i is 0
    }
    
    public void SomeFunc(ref int i)
    {
       i = 1;
    }
