    public class MyGame
    {
        private AsyncEvent _gameShuttingDown;
    
        public event AsyncEventHandler GameShuttingDown
        {
            add => this._gameShuttingDown.Register(value);
            remove => this._gameShuttingDown.Unregister(value);
        }
    
        void ErrorHandler(string name, Exception ex)
        {
             // handle event error.
        }
    
        public MyGame()
        {
            this._gameShuttingDown = new AsyncEvent("GAME_SHUTTING_DOWN", this.ErrorHandler);.
        }
    }
