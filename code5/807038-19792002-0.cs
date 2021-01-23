    public ChildEntity(BlockEntity p)
    {
      Parent = p;
    }
    //Test just to show Parent can not be assigned elsewhere
    public void test()
    {
    //this line below will show compile error
      Parent = new BlockEntity();
    }
