    public static class GameControl
    {
        public static T GetControl<T>()
        {
            return (T)typeof(T).GetProperty("Instance").GetValue(null);
        }
    }
