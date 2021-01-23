    public interface IGameState
    {
      bool ToggleA { get; set; }
      bool ToggleB { get; set; }
      int A { get; set; }
      int B { get; set; }
    
      int ComplexStateAlteringMethod();
    }
