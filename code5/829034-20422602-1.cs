    class SomeUIClass
    {
      void AFunction()
      {
        Listener.Instance.Information += InformationHandling;
      }
      public void InformationHandling(DateTime timestamp)
      {
        // do something with the information
      }
    }
