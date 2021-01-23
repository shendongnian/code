    public static class GameControl
    {
        public static T GetControl<T>()
        {
            if(typeof(T) == typeof(GameTimeControl)
            {
                return GameTimeControl.Instance();
            }
            // TODO: other singletons
            return null;
        }
    }
