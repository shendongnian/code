    public static class Extensions
    {
        public static void IfAssignable<T, TState>(this object source, Action<T, TState> run, TState state) where T : class
        {
            var target = source as T;
            if (target != null)
            {
                run(target, state);
            }
        }
    }
