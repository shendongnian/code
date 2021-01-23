    public Something GetNextEnum(Something e)
    {
      switch(e)
      {
         case This:
           return That;
         case That:
           return It;
         case It:
           return This;
         default:
           throw new IndexOutOfRangeException();
      }
    }
