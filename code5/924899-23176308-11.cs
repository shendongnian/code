    public class GameState : IGameState
    {
      // This instance variable will only ever have one copy instantiated
      private static GameState _instance = new GameState();
    
      // Private constructor so the class cannot be instantiated outside of the class.
      // This ensures that no other class can create an instance of the class.
      private GameState() { }
    
      public static GameState Instance { get { return _instance; } }
    
      public bool ToggleA { get; set; }
      public bool ToggleB { get; set; }
      public int A { get; set; }
      public int A { get; set; }
    }
