    public class Controller
    {
      private IGameState _gameState;
      public Controller(IGameState gameState)
      {
        _gameState = gameState;
      }
    
      public void KeyPressed(string key)
      {
        // Implementation details go here, say you want to call the complex method when the 'A' key is pressed
        if (key == "A")
        {
          _gameState.ComplexStateAlteringMethod();
        }
      }
    }
