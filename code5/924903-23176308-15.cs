    public class StubGameState : IGameState
    {   
      public bool ToggleA { get; set; }
      public bool ToggleB { get; set; }
      public int A { get; set; }
      public int B { get; set; }
    
      public bool WasStateAlteringMethodCalled { get; private set; }
      public void ComplexStateAlteringMethod()
      {
        WasStateAltermingMethodCalled = true;
      }
    }
