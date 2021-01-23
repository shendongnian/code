    public abstract class GameControlRequestProcessor
    {
        private readonly Dictionary<KeyPressEnum, Action> _actionMap;
        private KeyPressEnum _lastKeyPressed;
        protected GameControlRequestProcessor(Dictionary<KeyPressEnum,Action> actionMap)
        { 
          _actionMap = actionMap;
        }
        
        protected abstract void Update( );
        protected void ProcessKeyPress(Dictionary<KeyPressEnum,Action> actionMap)
        {
          if(!actionMap.HasKey(_keyLastPressed))
          {
              if(_actionMap.HasKey(_keyLastPressed)) 
                 _actionMap[keyLastPressed]();
              else 
              {
                 //do something in the default case
              }
          }
          else 
            actionMap[_lastKeyPressed]();
        }
    }
