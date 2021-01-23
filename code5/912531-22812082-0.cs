    interface IOne
    {
      void Y();
    }
    interface ITwo
    {
      void Y();
    }
    interface IBoth : IOne, ITwo
    {
    }
    class Test
    {
      static void M(IBoth obj)
      {
        obj.Y();  // must not compile!
      }
    }
