    public void FooMethod(ClassType myClass)
    {
      var doesImplementIChange = myClass as IChangeStatus<SomeClass>
      if (doesImplementIChange != null)
      {
        // Do stuff..
      }
    }
