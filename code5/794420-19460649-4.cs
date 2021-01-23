    public void Manipulate()
    {
      lock(mutex)
      {
        //some operation
        list.add(new SomeClass());
      }
    }
    
