    public static class GameControl
    {
        public static T GetControl<T>()
        {
            if(typeof(T) == typeof(GameTimeControl)
            {
                return _gameTimeControlInstance;
            }
            // TODO: other singletons
            return null;
        }
    
        private static GameTimeControl _gameTimeControlInstance = new GameTimeControl();
    }
