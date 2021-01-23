    interface IBase
    {
      void Y();
    }
    interface IDerived : IBase
    {
      /* new */ void Y();
    }
    class Test
    {
      static void M(IDerived obj)
      {
        obj.Y();  // allowed; IDerived has two Y, but one hides the other
      }
    }
