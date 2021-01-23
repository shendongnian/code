    public static class Helpers
    {
        public static void Times(this int value, Action action)
        {
            for (int i = 0; i < value; i++)
            {
                action.Invoke();
            }
        }
    }
