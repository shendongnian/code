    private int localMember;
    public int publicProperty
    {
      get
      {
        return localMember;
      }
      set
      {
        localMember = value;
        //Do whatever you want here.
      }
    }
