    public Something GetNextEnum(Something e)
    {
      switch(e)
      {
         case This:
           return That;
         case That:
           return It
         default:
           throw new IndexOutOfRangeException();
      }
    }
