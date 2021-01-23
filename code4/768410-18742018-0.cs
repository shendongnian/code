    public static class ActionExtensions
    {
        public static void NullSafeInvoke(this Action action)
        {
            if (action != null)
            {
                action();
            }
        }
    }
