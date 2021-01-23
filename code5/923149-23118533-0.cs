    class EnhancedAction
    {
        public static Action<T1> Create<T1, T2>(Action<T1, T2> action, T2 parameter2)
        {
            return parameter1 => action(parameter1 , parameter2);
        }
    }
