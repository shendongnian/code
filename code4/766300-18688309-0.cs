    public delegate void ActionByRef<J>(ref J j);
    public static class MyExtensions
    {
        public static void ForEachByRef<T>(this List<T> list, ActionByRef<T> action)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                T t = list[i];
                action(ref t);
                list[i] = t;
            }
        }
    }
