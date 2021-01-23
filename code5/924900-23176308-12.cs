    public class SomeObject
    {
      private IGameState _gameState;
      public SomeObject(IGameState gameState)
      {
        _gameState = gameState;
      }
    
      public void SomeOperationOnGameState()
      {
        _gameState.ToggleA = true;
      }
    }
