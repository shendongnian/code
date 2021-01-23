    static class MyDelayedCaller
    {
        public static MyDelayedCaller<T1> Create<T1>(Action<T1> target, T1 param)
        {
            return new MyDelayedCaller<T1>(target, param1);
        }
        public static MyDelayedCaller<T1, T2> Create<T1, T2>(Action<T1, T2> target, T1 param1, T2 param2)
        {
            return new MyDelayedCaller<T1, T2>(target, param1, param2);
        }
    }
